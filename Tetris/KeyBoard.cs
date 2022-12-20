using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class KeyBoard
    {
        private MainWindow mainWindow = new MainWindow();
        private string sPlayerName = "";

        public void GetUppercase()
        {
            if (mainWindow.btn_Uppercase.Tag.ToString() == "1")
            {
                mainWindow.btn_Q.Content = "Q";
                mainWindow.btn_W.Content = "W";
                mainWindow.btn_E.Content = "E";
                mainWindow.btn_R.Content = "R";
                mainWindow.btn_T.Content = "T";
                mainWindow.btn_Z.Content = "Z";
                mainWindow.btn_U.Content = "U";
                mainWindow.btn_I.Content = "I";
                mainWindow.btn_UE.Content = "Ü";
                mainWindow.btn_A.Content = "A";
                mainWindow.btn_S.Content = "S";
                mainWindow.btn_D.Content = "D";
                mainWindow.btn_F.Content = "F";
                mainWindow.btn_G.Content = "G";
                mainWindow.btn_H.Content = "H";
                mainWindow.btn_J.Content = "J";
                mainWindow.btn_K.Content = "K";
                mainWindow.btn_L.Content = "L";
                mainWindow.btn_OE.Content = "Ö";
                mainWindow.btn_Y.Content = "Y";
                mainWindow.btn_X.Content = "X";
                mainWindow.btn_C.Content = "C";
                mainWindow.btn_V.Content = "V";
                mainWindow.btn_B.Content = "B";
                mainWindow.btn_N.Content = "N";
                mainWindow.btn_M.Content = "M";
                mainWindow.btn_O.Content = "O";
                mainWindow.btn_P.Content = "P";
                mainWindow.btn_AE.Content = "Ä";
            }
            else
            {
                mainWindow.btn_Q.Content = "q";
                mainWindow.btn_W.Content = "w";
                mainWindow.btn_E.Content = "e";
                mainWindow.btn_R.Content = "r";
                mainWindow.btn_T.Content = "t";
                mainWindow.btn_Z.Content = "z";
                mainWindow.btn_U.Content = "u";
                mainWindow.btn_I.Content = "i";
                mainWindow.btn_UE.Content = "ü";
                mainWindow.btn_A.Content = "a";
                mainWindow.btn_S.Content = "s";
                mainWindow.btn_D.Content = "d";
                mainWindow.btn_F.Content = "f";
                mainWindow.btn_G.Content = "g";
                mainWindow.btn_H.Content = "h";
                mainWindow.btn_J.Content = "j";
                mainWindow.btn_K.Content = "k";
                mainWindow.btn_L.Content = "l";
                mainWindow.btn_OE.Content = "ö";
                mainWindow.btn_Y.Content = "y";
                mainWindow.btn_X.Content = "x";
                mainWindow.btn_C.Content = "c";
                mainWindow.btn_V.Content = "v";
                mainWindow.btn_B.Content = "b";
                mainWindow.btn_N.Content = "n";
                mainWindow.btn_M.Content = "m";
                mainWindow.btn_O.Content = "o";
                mainWindow.btn_P.Content = "p";
                mainWindow.btn_AE.Content = "ä";
            }
        }

        public void GetSpace()
        {
            sPlayerName = sPlayerName + mainWindow.btn_Space.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public string GetAgree()
        {
            return sPlayerName;
        }

        public void GetBack()
        {
            sPlayerName = sPlayerName.Remove(sPlayerName.Length - 1);
            mainWindow.tb_PlayerName.Text = sPlayerName;
        }

        public void GetQ()
        {
            sPlayerName = sPlayerName + mainWindow.btn_Q.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
        }

        public void GetW()
        {
            sPlayerName = sPlayerName + mainWindow.btn_W.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetE()
        {
            sPlayerName = sPlayerName + mainWindow.btn_E.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetR()
        {
            sPlayerName = sPlayerName + mainWindow.btn_R.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetT()
        {
            sPlayerName = sPlayerName + mainWindow.btn_T.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetZ()
        {
            sPlayerName = sPlayerName + mainWindow.btn_Z.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetU()
        {
            sPlayerName = sPlayerName + mainWindow.btn_U.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetI()
        {
            sPlayerName = sPlayerName + mainWindow.btn_I.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetUE()
        {
            sPlayerName = sPlayerName + mainWindow.btn_UE.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetA()
        {
            sPlayerName = sPlayerName + mainWindow.btn_A.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetS()
        {
            sPlayerName = sPlayerName + mainWindow.btn_S.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetD()
        {
            sPlayerName = sPlayerName + mainWindow.btn_D.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetF()
        {
            sPlayerName = sPlayerName + mainWindow.btn_F.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetG()
        {
            sPlayerName = sPlayerName + mainWindow.btn_G.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetH()
        {
            sPlayerName = sPlayerName + mainWindow.btn_H.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetJ()
        {
            sPlayerName = sPlayerName + mainWindow.btn_J.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetK()
        {
            sPlayerName = sPlayerName + mainWindow.btn_K.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetL()
        {
            sPlayerName = sPlayerName + mainWindow.btn_L.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetOE()
        {
            sPlayerName = sPlayerName + mainWindow.btn_OE.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetY()
        {
            sPlayerName = sPlayerName + mainWindow.btn_Y.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetX()
        {
            sPlayerName = sPlayerName + mainWindow.btn_X.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetC()
        {
            sPlayerName = sPlayerName + mainWindow.btn_C.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetV()
        {
            sPlayerName = sPlayerName + mainWindow.btn_V.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetB()
        {
            sPlayerName = sPlayerName + mainWindow.btn_B.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetN()
        {
            sPlayerName = sPlayerName + mainWindow.btn_N.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetM()
        {
            sPlayerName = sPlayerName + mainWindow.btn_M.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetO()
        {
            sPlayerName = sPlayerName + mainWindow.btn_O.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetP()
        {
            sPlayerName = sPlayerName + mainWindow.btn_P.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }

        public void GetAE()
        {
            sPlayerName = sPlayerName + mainWindow.btn_AE.Content;
            mainWindow.tb_PlayerName.Text = sPlayerName;
            GetUppercase();
        }
    }
}
