using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3
{
    public class BugSweeperViewModel
    {
        async void DisplayWonAnimation()
        {
            congratulationsText.Scale = 0;
            congratulationsText.IsVisible = true;

            // Because IsVisible has been false, the text might not have a size yet, 
            //  in which case Measure will return a size.
            double congratulationsTextWidth = congratulationsText.GetSizeRequest(Double.PositiveInfinity, Double.PositiveInfinity).Request.Width;

            congratulationsText.Rotation = 0;
            await congratulationsText.RotateTo(3 * 360, 1000, Easing.CubicOut);

            double maxScale = 0.9 * board.Width / congratulationsTextWidth;
            await congratulationsText.ScaleTo(maxScale, 1000);

            foreach (View view in congratulationsText.Children)
            {
                view.Rotation = 0;
                await view.RotateTo(180);
                await view.ScaleTo(3, 100);
                await view.RotateTo(360);
                await view.ScaleTo(1, 100);
            }

            await DisplayPlayAgainButton();
        }
    }
}
