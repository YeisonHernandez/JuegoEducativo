using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Features2D;
using Emgu.CV.Util;
using Emgu.CV.Cuda;
using Emgu.CV.XFeatures2D;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace JuegoEducativoYeisonHernandez
{
    public partial class FrmPrincipal : Form
    {
        #region instancias
        private Mat current;
        private Capture cam;
        private VectorOfKeyPoint modelVkp;
        private UMat modelDescriptors;
        private Image<Gray, Byte> mano;
        private SURF surf;
        private int k;
        private double uniquenessThreshold;
        private double hessianThresh;
        private long matchTime;
        #endregion

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                k = 2;
                uniquenessThreshold = 0.8;
                hessianThresh = 400;
                matchTime = 0;

                cam = new Capture(0);
                saveHandModel();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void btnActiv_Click(object sender, EventArgs e)
        {
            Application.Idle += new EventHandler(processCam);
        }

        private void processCam(object sender, EventArgs e)
        {
            current = cam.QueryFrame();
            if (current != null)
            {
                //Image<Bgr, Byte> original = current.ToImage<Bgr, Byte>().Flip(Emgu.CV.CvEnum.FlipType.Horizontal);
                Detect_Hand();
                imgBxCam.Image = current;
                //Image<Gray, Byte> reflectd = new Image<Gray, byte>(original.Bitmap).Convert<Gray, Byte>();
                //Image<Gray, Byte> canny = reflectd.Canny(240, 360);
                //canny = canny.Flip(Emgu.CV.CvEnum.FlipType.Horizontal);
                //picBoxReflejo.Image = canny.ToBitmap();
            }
            else
            {
                MessageBox.Show(this.Text, "Problemas al acceder a la imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        private void saveHandModel()
        {
            // recurso una foto de la mano para que este sea el modelo de los puntos 
            mano = new Image<Gray, byte>(Application.StartupPath + "\\Recursos\\Mano.jpg");
            picBoxReflejo.Image = mano;
            //Vector con los puntos claves del modelo == mano
            modelVkp = new VectorOfKeyPoint();
            surf = new SURF(hessianThresh);
            //extrae las caract de la imagen modelo == mano:
            modelDescriptors = new UMat();
            //Leer descripción del metodo
            surf.DetectAndCompute(mano, null, modelVkp, modelDescriptors, false);

        }

        private void Detect_Hand()
        {
            Stopwatch watch;
            //Vector con los puntos claves de la imagen actuald en la camara;
            VectorOfKeyPoint observedVkp = new VectorOfKeyPoint();
            //Vector con los puntos donde se entrelazan los puntos del modelo y de la imagen en camara
            VectorOfVectorOfDMatch matches = null;
            //Matriz con los puntos donde se entrelazan los puntos del modelo y de la imagen en camara
            Mat mask;
            Mat homography = new Mat();

            using (UMat uModelImage = mano.Mat.ToUMat(AccessType.Read))
            using (UMat uObservedImage = current.ToUMat(AccessType.Read))
            {
                //Clase para extraer caracteristicas de una imagen
                watch = Stopwatch.StartNew();

                //extrae los datos de la imagen actual en camara
                UMat observedDescriptors = new UMat();
                surf.DetectAndCompute(current, null, observedVkp, observedDescriptors, false);
                //empieza el limbo xD

                BFMatcher matcher = new BFMatcher(DistanceType.L2);
                matcher.Add(modelDescriptors);

                matches = new VectorOfVectorOfDMatch();

                matcher.KnnMatch(observedDescriptors, matches, k, null);
                mask = new Mat(matches.Size, 1, DepthType.Cv8U, 1);
                mask.SetTo(new MCvScalar(255));

                Features2DToolbox.VoteForUniqueness(matches, uniquenessThreshold, mask);

                int nonZero = CvInvoke.CountNonZero(mask);
                if (nonZero > 4)
                {
                    nonZero = Features2DToolbox.VoteForSizeAndOrientation(modelVkp, observedVkp,
                       matches, mask, 1.5, 20);
                    if (nonZero >= 4)
                        homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelVkp, observedVkp,
                            matches, mask, 2);
                    // Features2DToolbox.DrawMatches(new Image<Gray, byte>(picBoxReflejo.Image.Bitmap), modelVkp, current, observedVkp, matches, homography, new MCvScalar(255, 255, 255), new MCvScalar(255, 255, 255), mask);
                }
                watch.Stop();
            }
            matchTime = watch.ElapsedMilliseconds;
        }
    }
    //''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

}

