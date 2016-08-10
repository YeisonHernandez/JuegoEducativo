using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandRecognition
{
    public class ColorSkinDetector
    {
        public abstract Image<Gray, Byte> Detectar_piel(Image<Bgr, Byte> Img, IColor min, IColor max);                
    }
}
