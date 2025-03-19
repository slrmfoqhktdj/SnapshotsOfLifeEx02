using System.Drawing;


namespace SnapshotsOfLifeEx02
{
    class PictureData
    {
        private int picture_width = 520;        // 사진 가로길이
        private int picture_height = 380;       // 사진 세로길이

        private int entry_width = 1200;         // 전체 이미지 가로길이
        private int entry_height = 1800;        // 전체 이미지 세로길이

        private float frame_start_x = 18.5f;      // 프레임 시작지점
        private float frame_start_y = 25.5f;      // 프레임 시작지점



        private int frame_picture_height = 666;     // 프레임 사진영역 높이
        private int frame_picture_width_distance = 52;     // 프레임 사진영역과의 가로길이
        private int frame_picture_height_distance = 29;     // 프레임 사진영역과의 세로길이
        private int frame_picture_height_distance_upper = 14;     
        private int frame_picture_height_distance_bottom = 15;     

        private int frame_first_distance = 51;     // 프레임 처음 시작 부분의 틈



        private float picture_width_distance = 28.5f;  // 사진과의 가로 거리

        private float picture_height_distance = 15f;  // 사진과의 세로 거리

        private int picture_height_distance_upper = 7;  // 사진과의 세로 거리 절반 위쪽

        private int picture_height_distance_bottom = 8;  // 사진과의 세로 거리 절반 아랫쪽


        // 사진 위에 글쓰가 있는 경우

        private float first_distance = 162;    // 처음 시작부분의 틈
        private float last_distance = 26;   // 마지막 부분의 틈
        private float first_distance_starty = 162;   // y값 시작(웨 글씨가 있는 경우 )

        // 사진 아래에 글씨가 있는 경우
        /*        private float first_distance = 26;    // 처음 시작부분의 틈
                private float last_distance = 162;   // 마지막 부분의 틈
                private float first_distance_starty = 35;   // y값 시작(아래 글씨가 있는 경우 오차값 수정본 = first_distance값에 오차 +)*/

        private int timer_time_limit = 13;  // 프리뷰 보여지는 초 수 


        private Color picture_bg_color = Color.White;   // 사진 배경 색




        public int GetFramePictureHeight() { return frame_picture_height; }
        public float GetFramePictureWidthDistance() { return frame_picture_width_distance; }
        public float GetFramePictureHeightDistance() { return frame_picture_height_distance; }
        public int GetFramePictureHeightDistanceUpper() { return frame_picture_height_distance_upper; }
        public int GetFramePictureHeightDistanceBottom() { return frame_picture_height_distance_bottom; }
        public float GetFrameFirstDistance() { return frame_first_distance; }





        public int GetPictureWidth() { return picture_width; }
        public int GetPictureHeight() { return picture_height; }
        public int GetEntryWidth() { return entry_width; }
        public int GetEntryHeight() { return entry_height; }
        public float GetFrameStartX() { return frame_start_x; }
        public float GetFrameStartY() { return frame_start_y; }
        public float GetPictureWidthDistance() { return picture_width_distance; }
        public float GetPictureHeightDistance() { return picture_height_distance; }
        public int GetPictureHeightDistanceUpper() { return picture_height_distance_upper; }
        public int GetPictureHeightDistanceBottom() { return picture_height_distance_bottom; }
        public float GetFirstDistance() { return first_distance; }
        public float GetFirstDistanceStartY() { return first_distance_starty; }
        public float GetLastDistance() { return last_distance; }
        public Color GetPictureBGColor() { return picture_bg_color; }



        public int GetTimerTimeLimit() { return timer_time_limit; }

        //x: 원본 이미지의 x 좌표
        //y: 원본 이미지의 y 좌표
        //width: (x, y) 좌표에서의 이미지 너비(가로 크기)
        //height: (x, y) 좌표에서의 이미지 높이(세로 크기)
        public Image ImageCut(Image img, float x, float y, int width, int height)
        {

            Bitmap newImage = new Bitmap(width, height);
            Graphics temp = Graphics.FromImage(newImage);

            temp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            // 자르기
            temp.DrawImage(img,
                    new RectangleF(0f, 0f, width, height),
                    new RectangleF(x, y, width, height),
                    GraphicsUnit.Pixel);

            temp.Dispose();
            return newImage;
        }


        public Bitmap CropAndResizeBitmap(Bitmap sourceBitmap, float targetWidth, float targetHeight)
        {
           
            double targetAspectRatio = (double)targetWidth / targetHeight;
            double sourceAspectRatio = (double)sourceBitmap.Width / sourceBitmap.Height;

            Rectangle cropArea;

            // 비율에 맞게 잘라낼 영역 계산
            if (sourceAspectRatio > targetAspectRatio)
            {
                // 원본 이미지가 더 넓은 경우
                int newWidth = (int)(sourceBitmap.Height * targetAspectRatio);
                int x = (sourceBitmap.Width - newWidth) / 2; // 중앙 정렬
                cropArea = new Rectangle(x, 0, newWidth, sourceBitmap.Height);
            }
            else
            {
                // 원본 이미지가 더 높은 경우
                int newHeight = (int)(sourceBitmap.Width / targetAspectRatio);
                int y = (sourceBitmap.Height - newHeight) / 2; // 중앙 정렬
                cropArea = new Rectangle(0, y, sourceBitmap.Width, newHeight);
            }

            // 잘라낸 비트맵 생성
            Bitmap croppedBitmap = new Bitmap((int)targetWidth, (int)targetHeight);
            using (Graphics g = Graphics.FromImage(croppedBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(sourceBitmap, new Rectangle(0, 0, (int)targetWidth, (int)targetHeight), cropArea, GraphicsUnit.Pixel);
            }

            return croppedBitmap;
        }

        //테마 파일 이름으로 사진타입을 나눔
        public bool ThemaType(string frame_name)
        {
            return frame_name.Split('_').Length == 2;
        }

    }
}
