﻿using System;
using Android.Graphics;
using Android.Media;

namespace EmotionClient.Droid
{
    public static class BitmapHelpers
    {
        public static Bitmap GetAndRotateBitmap(string fileName)
        {
            Bitmap bitmap = BitmapFactory.DecodeFile(fileName);
            using (Matrix mtx = new Matrix())
            {
                if (Android.OS.Build.Product.Contains("Emulator"))
                {
                    mtx.PreRotate(90);
                }
                else
                {
                    ExifInterface exif = new ExifInterface(fileName);
                    var orientation = (Orientation)exif.GetAttributeInt(ExifInterface.TagOrientation, (int)Orientation.Normal);
                    switch (orientation)
                    {
                    case Orientation.Rotate90:
                        mtx.PreRotate(90);
                        break;
                    case Orientation.Rotate180:
                        mtx.PreRotate(180);
                        break;
                    case Orientation.Rotate270:
                        mtx.PreRotate(270);
                        break;
                    case Orientation.Normal:
                        // Normal, do nothing
                        break;
                    default:
                        break;
                    }
                }
                if (mtx != null)
                    bitmap = Bitmap.CreateBitmap(bitmap, 0, 0, bitmap.Width, bitmap.Height, mtx, false);
            }
            return bitmap;
        }
    }
}
