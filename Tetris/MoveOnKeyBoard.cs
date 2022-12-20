using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tetris
{
    public class MoveOnKeyBoard
    {
        private MainWindow mainWindow = new MainWindow();

        public void MoveToUppercase()
        {
            mainWindow.btn_Uppercase.Tag = "1";
            mainWindow.btn_BackToMainMenu.Tag = "0";
            mainWindow.btn_Q.Tag = "0";
            mainWindow.btn_A.Tag = "0";
            mainWindow.btn_Y.Tag = "0";

            mainWindow.btn_Uppercase.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_BackToMainMenu.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_Q.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_A.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_Y.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToSpace()
        {
            mainWindow.btn_Space.Tag = "1";
            mainWindow.btn_BackToMainMenu.Tag = "0";
            mainWindow.btn_Agree.Tag = "0";
            mainWindow.btn_Y.Tag = "0";
            mainWindow.btn_X.Tag = "0";
            mainWindow.btn_C.Tag = "0";
            mainWindow.btn_V.Tag = "0";
            mainWindow.btn_B.Tag = "0";
            mainWindow.btn_N.Tag = "0";
            mainWindow.btn_M.Tag = "0";
            mainWindow.btn_O.Tag = "0";
            mainWindow.btn_P.Tag = "0";
            mainWindow.btn_AE.Tag = "0";

            mainWindow.btn_Space.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_BackToMainMenu.Background= new SolidColorBrush(Colors.Green);
            mainWindow.btn_Agree.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_Y.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_X.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_C.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_V.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_B.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_N.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_M.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_O.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_P.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_AE.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToAgree()
        {
            mainWindow.btn_Agree.Tag = "1";
            mainWindow.btn_Space.Tag = "0";
            mainWindow.btn_Back.Tag = "0";
            mainWindow.btn_AE.Tag = "0";
            mainWindow.btn_OE.Tag = "0";

            mainWindow.btn_Agree.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_Space.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_Back.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_AE.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_OE.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToBack()
        {
            mainWindow.btn_Back.Tag = "1";
            mainWindow.btn_Agree.Tag = "0";
            mainWindow.btn_UE.Tag = "0";
            mainWindow.btn_OE.Tag = "0";

            mainWindow.btn_Back.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_Agree.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_UE.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_OE.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToBackToMainMenu()
        {
            mainWindow.btn_BackToMainMenu.Tag = "1";
            mainWindow.btn_Uppercase.Tag = "0";
            mainWindow.btn_Space.Tag = "0";

            mainWindow.btn_BackToMainMenu.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_Uppercase.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_Space.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToQ()
        {
            mainWindow.btn_Q.Tag = "1";
            mainWindow.btn_Uppercase.Tag = "0";
            mainWindow.btn_W.Tag = "0";
            mainWindow.btn_A.Tag = "0";

            mainWindow.btn_Q.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_Uppercase.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_W.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_A.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToW()
        {
            mainWindow.btn_W.Tag = "1";
            mainWindow.btn_Q.Tag = "0";
            mainWindow.btn_E.Tag = "0";
            mainWindow.btn_S.Tag = "0";

            mainWindow.btn_W.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_Q.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_E.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_S.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToE()
        {
            mainWindow.btn_E.Tag = "1";
            mainWindow.btn_W.Tag = "0";
            mainWindow.btn_R.Tag = "0";
            mainWindow.btn_D.Tag = "0";

            mainWindow.btn_E.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_W.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_R.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_D.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToR()
        {
            mainWindow.btn_R.Tag = "1";
            mainWindow.btn_E.Tag = "0";
            mainWindow.btn_T.Tag = "0";
            mainWindow.btn_F.Tag = "0";

            mainWindow.btn_R.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_E.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_T.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_F.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToT()
        {
            mainWindow.btn_T.Tag = "1";
            mainWindow.btn_R.Tag = "0";
            mainWindow.btn_Z.Tag = "0";
            mainWindow.btn_G.Tag = "0";

            mainWindow.btn_T.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_R.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_Z.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_G.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToZ()
        {
            mainWindow.btn_Z.Tag = "1";
            mainWindow.btn_T.Tag = "0";
            mainWindow.btn_U.Tag = "0";
            mainWindow.btn_H.Tag = "0";

            mainWindow.btn_Z.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_T.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_U.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_H.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToU()
        {
            mainWindow.btn_U.Tag = "1";
            mainWindow.btn_Z.Tag = "0";
            mainWindow.btn_I.Tag = "0";
            mainWindow.btn_J.Tag = "0";

            mainWindow.btn_U.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_Z.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_I.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_J.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToI()
        {
            mainWindow.btn_I.Tag = "1";
            mainWindow.btn_U.Tag = "0";
            mainWindow.btn_UE.Tag = "0";
            mainWindow.btn_K.Tag = "0";

            mainWindow.btn_I.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_U.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_UE.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_K.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToUE()
        {
            mainWindow.btn_UE.Tag = "1";
            mainWindow.btn_Back.Tag = "0";
            mainWindow.btn_I.Tag = "0";
            mainWindow.btn_L.Tag = "0";

            mainWindow.btn_UE.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_Back.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_I.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_L.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToA()
        {
            mainWindow.btn_A.Tag = "1";
            mainWindow.btn_Q.Tag = "0";
            mainWindow.btn_S.Tag = "0";
            mainWindow.btn_Y.Tag = "0";

            mainWindow.btn_A.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_Q.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_S.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_Y.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToS()
        {
            mainWindow.btn_S.Tag = "1";
            mainWindow.btn_W.Tag = "0";
            mainWindow.btn_A.Tag = "0";
            mainWindow.btn_D.Tag = "0";
            mainWindow.btn_X.Tag = "0";

            mainWindow.btn_S.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_W.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_A.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_D.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_X.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToD()
        {
            mainWindow.btn_D.Tag = "1";
            mainWindow.btn_E.Tag = "0";
            mainWindow.btn_S.Tag = "0";
            mainWindow.btn_F.Tag = "0";
            mainWindow.btn_C.Tag = "0";

            mainWindow.btn_D.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_E.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_S.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_F.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_C.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToF()
        {
            mainWindow.btn_F.Tag = "1";
            mainWindow.btn_R.Tag = "0";
            mainWindow.btn_D.Tag = "0";
            mainWindow.btn_G.Tag = "0";
            mainWindow.btn_V.Tag = "0";

            mainWindow.btn_F.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_R.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_D.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_G.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_V.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToG()
        {
            mainWindow.btn_G.Tag = "1";
            mainWindow.btn_T.Tag = "0";
            mainWindow.btn_F.Tag = "0";
            mainWindow.btn_H.Tag = "0";
            mainWindow.btn_B.Tag = "0";

            mainWindow.btn_G.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_T.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_F.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_H.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_B.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToH()
        {
            mainWindow.btn_H.Tag = "1";
            mainWindow.btn_Z.Tag = "0";
            mainWindow.btn_G.Tag = "0";
            mainWindow.btn_J.Tag = "0";
            mainWindow.btn_N.Tag = "0";

            mainWindow.btn_H.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_Z.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_G.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_J.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_N.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToJ()
        {
            mainWindow.btn_J.Tag = "1";
            mainWindow.btn_U.Tag = "0";
            mainWindow.btn_H.Tag = "0";
            mainWindow.btn_K.Tag = "0";
            mainWindow.btn_M.Tag = "0";

            mainWindow.btn_J.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_U.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_H.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_K.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_M.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToK()
        {
            mainWindow.btn_K.Tag = "1";
            mainWindow.btn_I.Tag = "0";
            mainWindow.btn_J.Tag = "0";
            mainWindow.btn_L.Tag = "0";
            mainWindow.btn_O.Tag = "0";

            mainWindow.btn_K.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_I.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_J.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_L.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_O.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToL()
        {
            mainWindow.btn_L.Tag = "1";
            mainWindow.btn_I.Tag = "0";
            mainWindow.btn_K.Tag = "0";
            mainWindow.btn_OE.Tag = "0";
            mainWindow.btn_P.Tag = "0";

            mainWindow.btn_L.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_I.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_K.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_OE.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_P.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToOE()
        {
            mainWindow.btn_OE.Tag = "1";
            mainWindow.btn_L.Tag = "0";
            mainWindow.btn_AE.Tag = "0";

            mainWindow.btn_OE.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_L.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_AE.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToY()
        {
            mainWindow.btn_Y.Tag = "1";
            mainWindow.btn_A.Tag = "0";
            mainWindow.btn_X.Tag = "0";

            mainWindow.btn_Y.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_A.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_X.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToX()
        {
            mainWindow.btn_X.Tag = "1";
            mainWindow.btn_S.Tag = "0";
            mainWindow.btn_Y.Tag = "0";
            mainWindow.btn_C.Tag = "0";

            mainWindow.btn_X.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_S.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_Y.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_C.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToC()
        {
            mainWindow.btn_C.Tag = "1";
            mainWindow.btn_D.Tag = "0";
            mainWindow.btn_X.Tag = "0";
            mainWindow.btn_V.Tag = "0";

            mainWindow.btn_C.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_D.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_X.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_V.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToV()
        {
            mainWindow.btn_V.Tag = "1";
            mainWindow.btn_F.Tag = "0";
            mainWindow.btn_C.Tag = "0";
            mainWindow.btn_B.Tag = "0";

            mainWindow.btn_V.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_F.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_C.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_B.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToB()
        {
            mainWindow.btn_B.Tag = "1";
            mainWindow.btn_Space.Tag = "0";
            mainWindow.btn_G.Tag = "0";
            mainWindow.btn_V.Tag = "0";
            mainWindow.btn_N.Tag = "0";

            mainWindow.btn_B.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_Space.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_G.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_V.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_N.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToN()
        {
            mainWindow.btn_N.Tag = "1";
            mainWindow.btn_H.Tag = "0";
            mainWindow.btn_B.Tag = "0";
            mainWindow.btn_M.Tag = "0";

            mainWindow.btn_N.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_H.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_B.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_M.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToM()
        {
            mainWindow.btn_M.Tag = "1";
            mainWindow.btn_J.Tag = "0";
            mainWindow.btn_N.Tag = "0";
            mainWindow.btn_O.Tag = "0";

            mainWindow.btn_M.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_J.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_N.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_O.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToO()
        {
            mainWindow.btn_O.Tag = "1";
            mainWindow.btn_K.Tag = "0";
            mainWindow.btn_M.Tag = "0";
            mainWindow.btn_P.Tag = "0";

            mainWindow.btn_O.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_K.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_M.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_P.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToP()
        {
            mainWindow.btn_P.Tag = "1";
            mainWindow.btn_L.Tag = "0";
            mainWindow.btn_O.Tag = "0";
            mainWindow.btn_AE.Tag = "0";

            mainWindow.btn_P.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_L.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_O.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_AE.Background = new SolidColorBrush(Colors.Green);
        }

        public void MoveToAE()
        {
            mainWindow.btn_AE.Tag = "1";
            mainWindow.btn_OE.Tag = "0";
            mainWindow.btn_P.Tag = "0";

            mainWindow.btn_AE.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_OE.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_P.Background = new SolidColorBrush(Colors.Green);
        }
    }
}
