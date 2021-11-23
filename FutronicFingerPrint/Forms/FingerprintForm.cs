using Futronic.Infrastructure.Services;
using Futronic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutronicFingerPrint.Forms
{
    [Serializable]
    public partial class FingerprintForm : Form
    {
        [DataMember]
        private byte[] Thumb;
        private byte[] IndexFinger;
        [DataMember]
        private byte[] MiddleFinger;
        [DataMember]
        private byte[] RingFinger;
        [DataMember]
        private byte[] LittleFinger;

        private IRepository<long, User> _repository;

        public FingerprintForm()
        {
            InitializeComponent();
        }

        private void FingerprintForm_Load(object sender, EventArgs e)
        {
            var repository = Activator.CreateInstance(typeof(IRepository<long, User>)) as IRepository<long, User>;
            _repository = repository;
        }

        private void btnCaptureThumb_Click(object sender, EventArgs e)
        {
            pictureThumb.Image = picturePreview.Image;
            this.Thumb = GetImageBytes(this.pictureThumb.Image);
        }

        private void btnCaptureIndex_Click(object sender, EventArgs e)
        {
            pictureIndex.Image = picturePreview.Image;
            this.IndexFinger = GetImageBytes(this.pictureIndex.Image);
        }

        private void btnCaptureMiddle_Click(object sender, EventArgs e)
        {
            pictureMiddle.Image = picturePreview.Image;
            this.MiddleFinger = GetImageBytes(this.pictureMiddle.Image);
        }

        private void btnCaptureRing_Click(object sender, EventArgs e)
        {
            pictureRing.Image = picturePreview.Image;
            this.RingFinger = GetImageBytes(this.pictureRing.Image);
        }

        private void btnCaptureLittle_Click(object sender, EventArgs e)
        {
            pictureLittle.Image = picturePreview.Image;
            this.LittleFinger = GetImageBytes(this.pictureLittle.Image);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private byte[] GetImageBytes(Image image)
        {
            MemoryStream ms = new();
            image.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }

        public FingerPrint GetFingerPrints()
        {
            return new FingerPrint
            {
                Thumb = this.Thumb,
                IndexFinger = IndexFinger,
                MiddleFinger = MiddleFinger,
                RingFinger = RingFinger,
                LittleFinger = LittleFinger
            };
        }
    }
}
