using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;



namespace ConsoleApplication1
{
    public class Game : GameWindow
    {

        int backTexture;

        public int LoadTexture(string file)
        {
            if (System.IO.File.Exists(file))
            {
                Bitmap bitmap = new Bitmap(file);

                int tex;
                GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

                GL.GenTextures(1, out tex);
                GL.BindTexture(TextureTarget.Texture2D, tex);

                BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                    OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
                bitmap.UnlockBits(data);


                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
                bitmap.Dispose();
                return tex;
            }
            else
            {
                return 0;  
            }
        }

        public static void DrawImage(int image)
        {
            GL.Enable(EnableCap.Texture2D);
            //Basically enables the alpha channel to be used in the color buffer
            GL.Enable(EnableCap.Blend);
            //The operation/order to blend
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            //Use for pixel depth comparing before storing in the depth buffer
            GL.Enable(EnableCap.DepthTest);
            GL.MatrixMode(MatrixMode.Projection);
            GL.PushMatrix();
            GL.LoadIdentity();

            GL.Ortho(0, 800, 0, 600, -1, 1);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.LoadIdentity();

            GL.BindTexture(TextureTarget.Texture2D, image);

            GL.Begin(BeginMode.Quads);

            GL.TexCoord2(0, 0);
            GL.Vertex3(0, 0, 0);

            GL.TexCoord2(1, 0);
            GL.Vertex3(200, 0, 0);

            GL.TexCoord2(1, 1);
            GL.Vertex3(200, 200, 0);

            GL.TexCoord2(0, 1);
            GL.Vertex3(0, 200, 0);

            GL.End();
            GL.Disable(EnableCap.Texture2D);
            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.DepthTest);
            GL.PopMatrix();

            GL.MatrixMode(MatrixMode.Projection);
            GL.PopMatrix();

            GL.MatrixMode(MatrixMode.Modelview);
            
            
        }

        protected override void OnLoad(EventArgs e)
        {
             base.OnLoad(e);
             //setup settings, load textures and sounds
             Title = "KingsNThings";
             GL.ClearColor(Color4.CornflowerBlue);
             
             backTexture = LoadTexture(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"images\back2.png"));


             System.Console.WriteLine(backTexture);

             
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            //add game logic and input handling
            if (Keyboard[Key.Escape])
            {
                Exit();
            }
        }
        protected override void OnRenderFrame(FrameEventArgs e){
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            DrawImage(backTexture);
            SwapBuffers();

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //resize method incase the player resizes the window
            GL.Viewport(0, 0, this.Width, this.Height);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           // GLControl control = new GLControl(new GraphicsMode(32, 24, 8, 4), 1, 0, GraphicsContextFlags.Default);
            using (Game gamewindow = new Game())
            {
                
                gamewindow.Run(30.0);
            }

        }
    }
}
