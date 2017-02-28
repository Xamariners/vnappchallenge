using System;

using UIKit;

namespace EmotionClient.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.        
        }

        partial void TakePhotoButton_TouchUpInside(UIButton sender)
        {
            TakePhotoButton.Enabled = false;
            UIImagePickerController picker = new UIImagePickerController();
            picker.SourceType = UIImagePickerControllerSourceType.Camera;
            picker.FinishedPickingMedia += async (o, e) => {
                ThePhoto.Image = e.OriginalImage;
                DetailsText.Text = "Processing...";
                ((UIImagePickerController)o).DismissViewController(true, null);
                using (var stream = e.OriginalImage.AsJPEG(.5f).AsStream())
                {
                    try
                    {
                        float happyValue = await Core.GetAverageHappinessScore(stream);
                        DetailsText.Text = Core.GetHappinessMessage(happyValue);
                    }
                    catch (Exception ex)
                    {
                        DetailsText.Text = ex.Message;
                    }
                    TakePhotoButton.Enabled = true;
                }
            };
            PresentModalViewController(picker, true);
        }
    }
}
