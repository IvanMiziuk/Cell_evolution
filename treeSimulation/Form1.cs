using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace treeSimulation
{
    public partial class Form1 : Form
    {
        Image saveImg;
        Graphics graphics;
        Bitmap bmp;


        Random random = new Random();
        const int
        R = 0,         //colorR
        G = 1,         //colorG
        B = 2,         //colorB
        type = 3,           //type
        brain = 4,          //brain
        energy = 5,         //energy
        water = 6,          //water
        light = 7,          //light
        rotate = 8,         //rotate
        activeGen = 9,     //activeGen
        previousBotX = 10,   //previousBotX
        previousBotY = 11,   //previousBotY
        nextBotX = 12,       //nextBotX
        nextBotY = 13,      //nextBotY
        old = 14;           //age
        int savedFrame = 0;
        //@"c:\temp\test.txt"
        //string saveAs = "D:\\AnimationWorld\\035";
        string saveAs = "";
        //string saveAs = "";

        int width = 256;
        int height = 256;

        int woterZone;

        int[,,,] Obj;
        int[] botZero;

        int coloreNaw = 0;

        int genomeLength = 64,
            genomeMax = 128;

        bool haveStep = true;
        int oldMax,
            oldMin,
            oldMidle,
            bots;
        string name;
        string maxAgeHistory = "";
        string middleAgeHistory = "";
        string botsHistory = "";
        public Form1()
        {
            InitializeComponent();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Step();
        }

        private void butStart_Click(object sender, EventArgs e)
        {
            Start(false);
        }
        private void butStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            SaveWorld("SaveBots");
        }
        private void butLoadWorld_Click_1(object sender, EventArgs e)
        {
            LoadWorld();
        }

        private void butSaveImage_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void butColor_Click(object sender, EventArgs e)
        {
            coloreNaw = (coloreNaw + 1) % 6;
            UpdatePicture();
        }
        private void butHistoryAge_Click(object sender, EventArgs e)
        {
            SaveHistoryAge();
        }

        void Start(bool isLoad)
        {
            genomeMax = (int)nudMaxValueGen.Value;
            genomeLength  = (int)nudGenLength.Value;
            if (!isLoad)
            {
                width = (int)nudWidth.Value;
                height = (int)nudHeight.Value;
            }
            pictureBox.Width = width;
            pictureBox.Height = height;

            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);

            saveImg = new Bitmap(width, height);
            graphics = Graphics.FromImage(saveImg);
            bmp = new Bitmap(saveImg);
            //color bot

            woterZone = (height / 4 * 3);
            if (!isLoad)
            {
                int x = width / 2;
                int y = height / 2;

                Obj = new int[width, height, 2, genomeLength];
                botZero = new int[2];
                botZero[0] = x;
                botZero[1] = y;
                //add Bot

                Obj[x, y, 0, R] = 127;//colorR
                Obj[x, y, 0, G] = 127;//colorG
                Obj[x, y, 0, B] = 127;//colorB
                Obj[x, y, 0, type] = 1;//type
                Obj[x, y, 0, brain] = 1;//brain
                Obj[x, y, 0, energy] = 5000;//energy
                Obj[x, y, 0, water] = 500;//water
                Obj[x, y, 0, light] = 0;//light
                Obj[x, y, 0, rotate] = 0;//rotate
                Obj[x, y, 0, activeGen] = 0;//activeGen
                Obj[x, y, 0, previousBotX] = -1;//previousBotX
                Obj[x, y, 0, previousBotY] = -1;//previousBotY
                Obj[x, y, 0, nextBotX] = -1;//nextBotX
                Obj[x, y, 0, nextBotY] = -1;//nextBotY
                                            //gen
                for (int gen = 0; gen < genomeLength; gen++)
                {
                    if (random.Next(5) != 0)
                    {
                        Obj[x, y, 1, gen] = 57;
                    }
                    else
                    {
                        Obj[x, y, 1, gen] = 40;
                    }
                }
            }
            if (saveAs == "")
                SaveImage();
            if (!isLoad)
                timer.Start();
        }
        void Stop()
        {
            if (timer.Enabled)
            {
                timer.Stop();
            }
            else
            {
                timer.Start();
            }
        }
        void Step()
        {
            label.Text = Convert.ToString(savedFrame);
            Light();
            Woter();

            int x = botZero[0],
                y = botZero[1];
            oldMax = 0;
            oldMin = 0;
            oldMidle = 0;
            bots = 0;
            if (x < 0 || y < 0)
            {
                timer.Stop();
            }
            else
            {
                while (true)
                {

                    Obj[x, y, 0, old]++;
                    if (oldMax < Obj[x, y, 0, old])
                        oldMax = Obj[x, y, 0, old];
                    if (oldMin > Obj[x, y, 0, old])
                        oldMin = Obj[x, y, 0, old];
                    oldMidle += Obj[x, y, 0, old];
                    bots++;

                    haveStep = true;
                    for (int i = 20 - Obj[x, y, 0, brain] * 4; i > 0; i--)
                    {
                        if (!haveStep)
                        {
                            break;
                        }

                        Obj[x, y, 0, energy]--;
                        switch (Obj[x, y, 1, Obj[x, y, 0, activeGen]])
                        {
                            case 32:
                                GenTurn(x, y);
                                break;
                            case 33:
                                GenTurnGlobal(x, y);
                                break;
                            case 34:
                                GenLookFamily(x, y);
                                break;
                            case 35:
                                GenLookFamilyGlobal(x, y);
                                break;
                            case 36:
                                GenLookType(x, y);
                                break;
                            case 37:
                                GenLookTypeGlobal(x, y);
                                break;
                            case 38:
                                GenLookBrain(x, y);
                                break;
                            case 39:
                                GenLookBrainGlobal(x, y);
                                break;
                            case 40:
                                GenAttack(x, y); haveStep = false;
                                break;
                            case 41:
                                GenAttackGlobal(x, y); haveStep = false;
                                break;
                            case 42:
                                GenTransfer(x, y);
                                break;
                            case 43:
                                GenTransferGlobal(x, y);
                                break;
                            case 44:
                                GenTransferEnergy(x, y);
                                break;
                            case 45:
                                GenTransferEnergyGlobal(x, y);
                                break;
                            case 46:
                                GenTransferWater(x, y);
                                break;
                            case 47:
                                GenTransferWaterGlobal(x, y);
                                break;
                            case 48:
                                GenShare(x, y);
                                break;
                            case 49:
                                GenShareGlobal(x, y);
                                break;
                            case 50:
                                GenShareEnergy(x, y);
                                break;
                            case 51:
                                GenShareEnergyGlobal(x, y);
                                break;
                            case 52:
                                GenShareWater(x, y);
                                break;
                            case 53:
                                GenShareWaterGlobal(x, y);
                                break;
                            case 54:
                                GenLookEnergy(x, y);
                                break;
                            case 55:
                                GenLookWater(x, y);
                                break;
                            case 56:
                                GenLookAround(x, y);
                                break;
                            case 57:
                                CreateEnergy(x, y); haveStep = false;
                                break;
                            case 58:
                                CreateEnergyWater(x, y); haveStep = false;
                                break;
                            case 59:
                                CreateEnergyLight(x, y); haveStep = false;
                                break;
                            case 60:
                                GenSentimentsIn(x, y, true); haveStep = false;
                                break;
                            case 61:
                                GenSentimentsInGlobal(x, y, true); haveStep = false;
                                break;
                            case 62:
                                GenSentiments(x, y, true); haveStep = false;
                                break;
                            default:
                                NextGen(x, y, 0, false);
                                break;
                        }

                        if (Obj[x, y, 0, energy] <= 0)
                            DieCell(x, y);


                    }
                    if (Obj[x, y, 0, energy] > 1000)
                        GenSentiments(x, y, false);

                    CorrectEW(x, y);
                    int nx = Obj[x, y, 0, nextBotX];
                    int ny = Obj[x, y, 0, nextBotY];
                    x = nx;
                    y = ny;
                    if (x == -1 || y == -1)
                        break;
                }
                oldMidle /= bots;

                lBots.Text = Convert.ToString(bots);
                lMaxAge.Text = Convert.ToString(oldMax);
                lMinaAge.Text = Convert.ToString(oldMidle);
                //if(savedFrame % 999 == 0)
                if (cbGravity.Checked)
                    Gravity();
                if(cbCamera.Checked)
                    UpdatePicture();
                if (savedFrame % 25 == 0 && saveAs != "")
                {
                    SaveColorManager();
                }
                if(savedFrame % 100 == 0 && saveAs != "")
                {
                    maxAgeHistory += Convert.ToString(oldMax) + "\n";
                    middleAgeHistory += Convert.ToString(oldMidle) + "\n";
                    botsHistory += Convert.ToString(bots) + "\n";
                }
                if(savedFrame % 1000 == 0 && saveAs != "")
                {
                    SaveHistoryAge();
                }
                savedFrame++;
            }
           
        }

        void Gravity()
        {
            for (int y = height / 3; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (Obj[x, y, 0, type] == -1)
                    {
                        if (Obj[x, y - 1, 0, type] == 0)
                        {
                            for (int i = 0; i < 15; i++)
                            {
                                Obj[x, y - 1, 0, i] = Obj[x, y, 0, i];
                                Obj[x, y, 0, i] = 0;
                            }
                            for (int i = 0; i < genomeLength; i++)
                            {
                                Obj[x, y - 1, 1, i] = Obj[x, y, 1, i];
                            }
                        }
                    }
                    if (Obj[x, y, 0, type] >= 1)
                    {
                        if (Obj[x, y - 1, 0, type] == 0)
                        {
                            int around = CheckingAroundGravityType(x, y);
                            if (around < 3)
                            {
                                int pX = Obj[x, y, 0, previousBotX];
                                int pY = Obj[x, y, 0, previousBotY];

                                int nX = Obj[x, y, 0, nextBotX];
                                int nY = Obj[x, y, 0, nextBotY];

                                if (pX == -1 || pY == -1)
                                {
                                    botZero[1] = y - 1;
                                }
                                else
                                {
                                    Obj[pX, pY, 0, nextBotY] = y - 1;
                                }
                                if (nX != -1 || nY != -1)
                                {
                                    Obj[nX, nY, 0, previousBotY] = y - 1;
                                }

                                for (int i = 0; i < 15; i++)
                                {
                                    Obj[x, y - 1, 0, i] = Obj[x, y, 0, i];
                                    Obj[x, y, 0, i] = 0;
                                }
                                for (int i = 0; i < genomeLength; i++)
                                {
                                    Obj[x, y - 1, 1, i] = Obj[x, y, 1, i];
                                }
                            }
                        }
                    }

                }
            }
        }
        void Light()
        {
            for (int x = 0; x < width; x++)
            {
                int sun = 0;
                for (int y = height - 1; y > height / 3; y--)
                {
                    if (Obj[x, y, 0, type] >= 1)
                    {
                        int around = CheckingAroundGravityLight(x, y);
                        sun -= around;
                        Obj[x, y, 0, light] = sun;
                    }
                    else if (sun < 50)
                    {
                        sun++;
                    }
                    if (sun <= 0)
                    {
                        break;
                    }
                }
            }
        }
        void Woter()
        {
            for (int X = 0; X < width; X++)
            {
                for (int Y = 0; Y < height; Y++)
                {

                    if (Obj[X, Y, 0, type] > 0)
                    {            
                        int moreObj = 0;
                        for (int x = -1; x < 2; x++)
                        {
                            for (int y = -1; y < 1; y++)
                            {
                                int sX = (X + x + width) % width;
                                int sY = Y + y;
                                if (sY < height && sY >= 0)
                                {
                                    switch (Obj[sX, sY, 0, type])
                                    {
                                        case -1:
                                            moreObj--;
                                            break;
                                        case 1:
                                            moreObj += 3;
                                            break;
                                        case 2:
                                            moreObj += 2;
                                            break;
                                        case 3:
                                            moreObj += 1;
                                            break;
                                    }
                                }
                            }
                        }
                        moreObj /= 9;
                        int addWoter = 0;
                        if (woterZone / 4 > 0)
                            addWoter = (-Y + woterZone) / (woterZone / 4) - moreObj;
                        if (addWoter > 0)
                            Obj[X, Y, 0, water] += addWoter;

                    }

                }
            }



        }

        void UpdatePicture()
        {
            if (graphics != null)
            {
                switch (coloreNaw)
                {
                    case 0:
                        PictureBot();
                        pictureBox.Image = saveImg;
                        lColorMode.Text = "Bot take energy";
                        break;
                    case 1:
                        PictureEnergy();
                        pictureBox.Image = saveImg;
                        lColorMode.Text = "Bot have energy";
                        break;
                    case 2:
                        PictureWater();
                        pictureBox.Image = saveImg;
                        lColorMode.Text = "Bot have water";
                        break;
                    case 3:
                        PictureType();
                        pictureBox.Image = saveImg;
                        lColorMode.Text = "Bot type";
                        break;
                    case 4:
                        PictureBrain();
                        pictureBox.Image = saveImg;
                        lColorMode.Text = "Bot brain";
                        break;
                    case 5:
                        PictureAge();
                        pictureBox.Image = saveImg;
                        lColorMode.Text = "Bot age";
                        break;
                   
                }
            }
            pictureBox.Refresh();


        }
        private void SaveColorManager()
        {
            if (graphics != null)
            {
                PictureBot();
                saveImg.Save(saveAs + "\\bots\\" + savedFrame + ".png");
                PictureEnergy();
                saveImg.Save(saveAs + "\\energy\\" + savedFrame + ".png");
                PictureWater();
                saveImg.Save(saveAs + "\\water\\" + savedFrame + ".png");
                PictureType();
                saveImg.Save(saveAs + "\\botsType\\" + savedFrame + ".png");
                PictureBrain();
                saveImg.Save(saveAs + "\\brain\\" + savedFrame + ".png");
                PictureAge();
                saveImg.Save(saveAs + "\\age\\" + savedFrame + ".png");
            }
        }
        void LoadWorld()
        {
            string loadas = "";
            OpenFileDialog FBD = new OpenFileDialog();
            FBD.Filter = "evo files (*.evo)|*.evo|All files (*.*)|*.*";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                loadas = FBD.FileName;
            }
            if (loadas != "")
            {
                string saveBot = System.IO.File.ReadAllText(loadas);
                width = saveBot[0];
                height = saveBot[1];
                botZero = new int[2];
                botZero[0] = saveBot[2];
                botZero[1] = saveBot[3];
                Start(true);
                int ca = 2;
                Obj = new int[width, height, 2, genomeLength];
                while (true)
                {
                    int x = saveBot[ca]; ca++;
                    int y = saveBot[ca]; ca++;
                    for (int i = 0; i < 14; i++)
                    {

                        if (i != type && i != nextBotX && i != nextBotY && i != previousBotX && i != previousBotY)
                            Obj[x, y, 0, i] = saveBot[ca];
                        else
                            Obj[x, y, 0, i] = saveBot[ca] - 1;
                        ca++;

                    }
                    for (int i = 0; i < genomeLength; i++)
                    {
                        Obj[x, y, 1, i] = saveBot[ca]; ca++;
                    }
                    int nx = Obj[x, y, 0, nextBotX];
                    int ny = Obj[x, y, 0, nextBotY];
                    x = nx;
                    y = ny;
                    if (x == -1 || y == -1)
                        break;
                }
                for (; ca < saveBot.Length;)
                {
                    int x = saveBot[ca]; ca++;
                    int y = saveBot[ca]; ca++;
                    Obj[x, y, 0, type] = -1;

                }
            }
        }

        void SaveImage()
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                saveAs = FBD.SelectedPath;
            }
            name = Convert.ToString(random.Next());
            System.IO.Directory.CreateDirectory(saveAs + "\\botsType");
            System.IO.Directory.CreateDirectory(saveAs + "\\brain");
            System.IO.Directory.CreateDirectory(saveAs + "\\bots");
            System.IO.Directory.CreateDirectory(saveAs + "\\energy");
            System.IO.Directory.CreateDirectory(saveAs + "\\water");
            System.IO.Directory.CreateDirectory(saveAs + "\\saveBot");
            System.IO.Directory.CreateDirectory(saveAs + "\\age");
        }
        void SaveWorld(string textsave)
        {
            if (saveAs == "")
            {
                FolderBrowserDialog FBD = new FolderBrowserDialog();
                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    saveAs = FBD.SelectedPath;
                }
            }
            System.IO.Directory.CreateDirectory(saveAs + "\\botsType");
            System.IO.Directory.CreateDirectory(saveAs + "\\brain");
            System.IO.Directory.CreateDirectory(saveAs + "\\bots");
            System.IO.Directory.CreateDirectory(saveAs + "\\energy");
            System.IO.Directory.CreateDirectory(saveAs + "\\water");
            System.IO.Directory.CreateDirectory(saveAs + "\\saveBot");
            System.IO.Directory.CreateDirectory(saveAs + "\\age");


            int[,,,] saveObj = Obj;
            string saveBot = "";
            saveBot += (char)width;
            saveBot += (char)height;
            int x = botZero[0],
                y = botZero[1];
            while (true)
            {
                saveBot += (char)x;
                saveBot += (char)y;
                for (int i = 0; i < 14; i++)
                {
                    if (i != type && i != nextBotX && i != nextBotY && i != previousBotX && i != previousBotY)
                        saveBot += (char)saveObj[x, y, 0, i];
                    else
                        saveBot += (char)(saveObj[x, y, 0, i] + 1);
                }
                for (int i = 0; i < genomeLength; i++)
                {
                    saveBot += (char)saveObj[x, y, 1, i];
                }
                int nx = Obj[x, y, 0, nextBotX];
                int ny = Obj[x, y, 0, nextBotY];
                x = nx;
                y = ny;
                if (x == -1 || y == -1)
                    break;
            }
            for (int X = 0; X < width; X++)
            {
                for (int Y = 0; Y < height; Y++)
                {
                    if (Obj[X, Y, 0, type] == -1)
                    {
                        saveBot += (char)X;
                        saveBot += (char)Y;
                    }
                }
            }
            System.IO.File.WriteAllText(saveAs + "\\saveBot\\" + textsave + ".evo", saveBot);

        }
        void SaveHistoryAge()
        {
            if (saveAs == "")
            {
                FolderBrowserDialog FBD = new FolderBrowserDialog();
                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    saveAs = FBD.SelectedPath;
                }
                System.IO.File.WriteAllText(saveAs + "\\maxHistoryAge.txt", maxAgeHistory);
                System.IO.File.WriteAllText(saveAs + "\\middleHistoryAge.txt", middleAgeHistory);
                System.IO.File.WriteAllText(saveAs + "\\botsHistory.txt", botsHistory);
            }
            else
            {
                System.IO.File.WriteAllText(saveAs + "\\maxHistoryAge.txt", maxAgeHistory);
                System.IO.File.WriteAllText(saveAs + "\\middleHistoryAge.txt", middleAgeHistory);
                System.IO.File.WriteAllText(saveAs + "\\botsHistory.txt", botsHistory);
            }
        }

        void PictureBot()
        {
            graphics.Clear(Color.Black);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int X = width - x;
                    int Y = height - y;
                    if (Obj[x, y, 0, type] > 0)
                    {
                        Color myColor = Color.FromArgb(255, Obj[x, y, 0, R], Obj[x, y, 0, G], Obj[x, y, 0, B]);
                        SolidBrush myBrush = new SolidBrush(myColor);
                        graphics.FillRectangle(myBrush, X, Y, 1, 1);
                    }
                    else if (Obj[x, y, 0, type] == -1)
                    {
                        graphics.FillRectangle(Brushes.White, X, Y, 1, 1);
                    }
                }
            }
        }
        void PictureEnergy()
        {
            graphics.Clear(Color.Black);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (Obj[x, y, 0, type] >= 1)
                    {
                        int X = width - x;
                        int Y = height - y;

                        Color myColor = Color.FromArgb(255, 255, 255 - (Obj[x, y, 0, energy] / 4 + 255) % 255, 0);
                        SolidBrush myBrush = new SolidBrush(myColor);
                        graphics.FillRectangle(myBrush, X, Y, 1, 1);
                    }
                    else if (Obj[x, y, 0, type] == -1)
                    {
                        int X = width - x;
                        int Y = height - y;

                        graphics.FillRectangle(Brushes.White, X, Y, 1, 1);
                    }
                }
            }
        }
        void PictureWater()
        {
            graphics.Clear(Color.Black);
            int X = 0;
            int Y = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (Obj[x, y, 0, type] >= 1)
                    {
                        X = width - x;
                        Y = height - y;


                        Color myColor = Color.FromArgb(255, 0, 255 - (Obj[x, y, 0, water] / 4 + 255) % 255, 255);
                        SolidBrush myBrush = new SolidBrush(myColor);
                        graphics.FillRectangle(myBrush, X, Y, 1, 1);
                    }
                    else if (Obj[x, y, 0, type] == -1)
                    {
                        X = width - x;
                        Y = height - y;

                        graphics.FillRectangle(Brushes.White, X, Y, 1, 1);
                    }
                }
            }
        }
        void PictureType()
        {
            graphics.Clear(Color.Black);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (Obj[x, y, 0, type] >= 1)
                    {
                        int X = width - x;
                        int Y = height - y;

                        if (Obj[x, y, 0, type] == 1)
                            graphics.FillRectangle(Brushes.DarkRed, X, Y, 1, 1);
                        if (Obj[x, y, 0, type] == 2)
                            graphics.FillRectangle(Brushes.SaddleBrown, X, Y, 1, 1);
                        if (Obj[x, y, 0, type] == 3)
                            graphics.FillRectangle(Brushes.Green, X, Y, 1, 1);
                        if (Obj[x, y, 0, type] == 4)
                            graphics.FillRectangle(Brushes.Red, X, Y, 1, 1);
                    }
                    else if (Obj[x, y, 0, type] == -1)
                    {
                        int X = width - x;
                        int Y = height - y;

                        graphics.FillRectangle(Brushes.White, X, Y, 1, 1);
                    }
                }
            }
        }
        void PictureBrain()
        {
            graphics.Clear(Color.Black);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (Obj[x, y, 0, brain] >= 0 && Obj[x, y, 0, type] >= 1)
                    {
                        int X = width - x;
                        int Y = height - y;

                        if (Obj[x, y, 0, brain] == 0)
                            graphics.FillRectangle(Brushes.Blue, X, Y, 1, 1);
                        if (Obj[x, y, 0, brain] == 1)
                            graphics.FillRectangle(Brushes.Yellow, X, Y, 1, 1);
                        if (Obj[x, y, 0, brain] == 2)
                            graphics.FillRectangle(Brushes.Green, X, Y, 1, 1);
                        if (Obj[x, y, 0, brain] == 3)
                            graphics.FillRectangle(Brushes.Red, X, Y, 1, 1);
                    }
                    if (Obj[x, y, 0, type] == -1)
                    {
                        int X = width - x;
                        int Y = height - y;

                        graphics.FillRectangle(Brushes.White, X, Y, 1, 1);
                    }
                }
            }
        }
        void PictureAge()
        {
            graphics.Clear(Color.Black);

            int a = oldMax / 255;
            a++;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (Obj[x, y, 0, type] >= 1)
                    {
                        int X = width - x;
                        int Y = height - y;

                        Color myColor = Color.FromArgb(255, 255, 0, 255 - Obj[x, y, 0, old] / a);
                        SolidBrush myBrush = new SolidBrush(myColor);
                        graphics.FillRectangle(myBrush, X, Y, 1, 1);
                    }
                    else if (Obj[x, y, 0, type] == -1)
                    {
                        int X = width - x;
                        int Y = height - y;

                        graphics.FillRectangle(Brushes.White, X, Y, 1, 1);
                    }
                }
            }
        }

        private void CreateEnergy(int x, int y)
        {
            if (Obj[x, y, 0, light] > 0)
            {
                if (Obj[x, y, 0, water] > 0)
                {
                    int WaterUse = 1000 / 250;
                    if(WaterUse * Obj[x, y, 0, light] > 1000)
                    {
                        Obj[x, y, 0, energy] += 3 * Obj[x, y, 0, light];
                        Obj[x, y, 0, water] -= 3;
                    }
                    else
                    {
                        if (Obj[x, y, 0, water] >= WaterUse)
                        {
                            Obj[x, y, 0, energy] += WaterUse * Obj[x, y, 0, light];
                            Obj[x, y, 0, water] -= WaterUse;
                        }
                        else
                        {
                            Obj[x, y, 0, energy] += WaterUse * Obj[x, y, 0, light];
                            Obj[x, y, 0, water]  = 0;
                        }
                    }
                    ChangeColor(x, y, 'G');
                }
            }

            NextGen(x, y, 1, true);
        }
        private void CreateEnergyWater(int x, int y)
        {
            if (Obj[x, y, 0, water] * 4 > 1000)
            {
                Obj[x, y, 0, energy] += 1000;
                Obj[x, y, 0, water] -= 250;
                ChangeColor(x, y, 'B');
            }
            else if (Obj[x, y, 0, water] > 0)
            {
                Obj[x, y, 0, energy] += Obj[x, y, 0, water] * 4;
                Obj[x, y, 0, water] = 0;
                ChangeColor(x, y, 'B');
            }
            NextGen(x, y, 1, true);
        }
        private void CreateEnergyLight(int x, int y)
        {
            if (Obj[x, y, 0, light] > 0)
            {
                Obj[x, y, 0, energy] += Obj[x, y, 0, light] / 2;
            }
            NextGen(x, y, 1, true);
        }

        void NextGen(int x, int y, int check, bool isAdd)
        {
            int sizeGen = 64;
            int startGen = 0;
            switch (Obj[x, y, 0, brain])
            {
                case 1:
                    sizeGen = genomeLength-1;
                    startGen = 0;
                    break;
                case 2:
                    sizeGen = (genomeLength-1) / 2;
                    startGen = genomeLength - sizeGen;
                    break;
                case 3:
                    sizeGen = (genomeLength - 1) / 4;
                    startGen = genomeLength - sizeGen;
                    break;
            }
            if (isAdd)
                Obj[x, y, 0, activeGen] = startGen + (Obj[x, y, 0, activeGen] + check + sizeGen) % sizeGen;
            else
                Obj[x, y, 0, activeGen] = startGen + (Obj[x, y, 0, activeGen] + Obj[x, y, 1, (Obj[x, y, 0, activeGen] + check + sizeGen) % sizeGen] + sizeGen) % sizeGen;
        }

        private void DieCell(int x, int y)
        {
            Obj[x, y, 0, type] = -1;
            Obj[x, y, 0, energy] = 100;
            Obj[x, y, 0, water] = 100;

            int prX = Obj[x, y, 0, previousBotX];
            int prY = Obj[x, y, 0, previousBotY];

            int ntX = Obj[x, y, 0, nextBotX];
            int ntY = Obj[x, y, 0, nextBotY];

            if (prX == -1 || prY == -1)
            {
                botZero[0] = ntX;
                botZero[1] = ntY;
            }
            else
            {
                Obj[prX, prY, 0, nextBotX] = ntX;
                Obj[prX, prY, 0, nextBotY] = ntY;
            }

            if (ntX != -1 || ntY != -1)
            {
                Obj[ntX, ntY, 0, previousBotX] = prX;
                Obj[ntX, ntY, 0, previousBotY] = prY;
            }

            haveStep = false;
        }
        private void KilledCell(int x, int y, int killerX, int killerY)
        {
            Obj[x, y, 0, type] = 0;

            int prX = Obj[x, y, 0, previousBotX];
            int prY = Obj[x, y, 0, previousBotY];

            int ntX = Obj[x, y, 0, nextBotX];
            int ntY = Obj[x, y, 0, nextBotY];

            if (prX == -1 || prY == -1)
            {
                botZero[0] = ntX;
                botZero[1] = ntY;
            }
            else
            {
                Obj[prX, prY, 0, nextBotX] = ntX;
                Obj[prX, prY, 0, nextBotY] = ntY;
            }

            if (ntX != -1 || ntY != -1)
            {
                Obj[ntX, ntY, 0, previousBotX] = prX;
                Obj[ntX, ntY, 0, previousBotY] = prY;
            }
            haveStep = false;

        }

        private void GenSentiments(int x, int y, bool genSent)
        {
            int[] chieldPos = CheckOnSentiments(x, y);
            int cX = chieldPos[0];
            int cY = chieldPos[1];
            haveStep = false;
            if (cY != -1 || cX != -1)
            {
                if (Obj[x, y, 0, energy] > 150)
                {
                    Obj[x, y, 0, energy] -= 150;
                    Obj[x, y, 0, energy] /= 2;
                    Obj[x, y, 0, water] /= 2;

                    Obj[cX, cY, 0, R] = Obj[x, y, 0, R];//colorR
                    Obj[cX, cY, 0, G] = Obj[x, y, 0, G];//colorG
                    Obj[cX, cY, 0, B] = Obj[x, y, 0, B];//colorB
                    Obj[cX, cY, 0, type] = Obj[x, y, 0, type];//type
                    Obj[cX, cY, 0, brain] = Obj[x, y, 0, brain];//brain
                    Obj[cX, cY, 0, energy] = Obj[x, y, 0, energy];//energy
                    Obj[cX, cY, 0, water] = Obj[x, y, 0, water];//water
                    Obj[cX, cY, 0, light] = 0;//light
                    Obj[cX, cY, 0, rotate] = Obj[x, y, 0, rotate];//rotate
                    Obj[cX, cY, 0, activeGen] = 0;//activeGen
                    Obj[cX, cY, 0, previousBotX] = Obj[x, y, 0, previousBotX];//previousBotX
                    Obj[cX, cY, 0, previousBotY] = Obj[x, y, 0, previousBotY];//previousBotY
                    Obj[cX, cY, 0, nextBotX] = x;//nextBotX
                    Obj[cX, cY, 0, nextBotY] = y;//nextBotY
                    Obj[cX, cY, 0, old] = 0;

                    int PrevX = Obj[x, y, 0, previousBotX];
                    int PrevY = Obj[x, y, 0, previousBotY];

                    Obj[x, y, 0, previousBotX] = cX;
                    Obj[x, y, 0, previousBotY] = cY;

                    if (PrevX == -1 || PrevY == -1)
                    {
                        botZero[0] = cX;
                        botZero[1] = cY;
                    }
                    else
                    {
                        Obj[PrevX, PrevY, 0, nextBotX] = cX;
                        Obj[PrevX, PrevY, 0, nextBotY] = cY;
                    }
                    for (int g = 0; g < genomeLength; g++)
                    {
                        Obj[cX, cY, 1, g] = Obj[x, y, 1, g];
                    }

                    if (genSent)
                    {
                        int typeObj = genomeMax / 2;
                        Obj[cX, cY, 0, type] = (Obj[x, y, 1, Obj[x, y, 1, (activeGen + 1 + genomeLength) % genomeLength] % genomeLength] / typeObj) + 1;//type
                        Obj[cX, cY, 0, brain] = (Obj[x, y, 1, Obj[x, y, 1, (activeGen + 2 + genomeLength) % genomeLength] % genomeLength] / typeObj) + 1;//type

                        NextGen(x, y, 3, true);
                    }
                    if (random.Next(4) == 0)
                    {
                        Obj[cX, cY, 1, random.Next(genomeLength)] = random.Next(genomeMax);
                        if (random.Next(4) == 0)
                        {
                            Obj[cX, cY, 0, type] = random.Next(1, 4);
                        }
                        if (random.Next(4) == 0)
                        {
                            Obj[cX, cY, 0, brain] = random.Next(0, 3);
                        }
                    }

                }
                else
                {
                    DieCell(x, y);
                }
            }
            else
            {
                DieCell(x, y);
            }
        }

        private void GenSentimentsIn(int x, int y, bool genSent)
        {
            int[] chieldPos = CheckOnSentimentsIn(x, y);
            int cX = chieldPos[0];
            int cY = chieldPos[1];
            haveStep = false;
            if (cY != -1 || cX != -1)
            {
                Obj[x, y, 0, energy] -= 150;
                if (Obj[x, y, 0, energy] > 150)
                {
                    Obj[x, y, 0, energy] /= 2;
                    Obj[x, y, 0, water] /= 2;

                    Obj[cX, cY, 0, R] = Obj[x, y, 0, R];//colorR
                    Obj[cX, cY, 0, G] = Obj[x, y, 0, G];//colorG
                    Obj[cX, cY, 0, B] = Obj[x, y, 0, B];//colorB
                    Obj[cX, cY, 0, type] = Obj[x, y, 0, type];//type
                    Obj[cX, cY, 0, brain] = Obj[x, y, 0, brain];//brain
                    Obj[cX, cY, 0, energy] = Obj[x, y, 0, energy];//energy
                    Obj[cX, cY, 0, water] = Obj[x, y, 0, water];//water
                    Obj[cX, cY, 0, light] = 0;//light
                    Obj[cX, cY, 0, rotate] = Obj[x, y, 0, rotate];//rotate
                    Obj[cX, cY, 0, activeGen] = 0;//activeGen
                    Obj[cX, cY, 0, previousBotX] = Obj[x, y, 0, previousBotX];//previousBotX
                    Obj[cX, cY, 0, previousBotY] = Obj[x, y, 0, previousBotY];//previousBotY
                    Obj[cX, cY, 0, nextBotX] = x;//nextBotX
                    Obj[cX, cY, 0, nextBotY] = y;//nextBotY
                    Obj[cX, cY, 0, old] = 0;

                    int PrevX = Obj[x, y, 0, previousBotX];
                    int PrevY = Obj[x, y, 0, previousBotY];

                    Obj[x, y, 0, previousBotX] = cX;
                    Obj[x, y, 0, previousBotY] = cY;

                    if (PrevX == -1 || PrevY == -1)
                    {
                        botZero[0] = cX;
                        botZero[1] = cY;
                    }
                    else
                    {
                        Obj[PrevX, PrevY, 0, nextBotX] = cX;
                        Obj[PrevX, PrevY, 0, nextBotY] = cY;
                    }
                    for (int g = 0; g < genomeLength; g++)
                    {
                        Obj[cX, cY, 1, g] = Obj[x, y, 1, g];
                    }

                    if (genSent)
                    {
                        int typeObj = genomeMax / 2;
                        Obj[cX, cY, 0, type] = (Obj[x, y, 1, Obj[x, y, 1, (activeGen + 2 + genomeLength) % genomeLength] % genomeLength] / typeObj) + 1;//type
                        Obj[cX, cY, 0, brain] = (Obj[x, y, 1, Obj[x, y, 1, (activeGen + 3 + genomeLength) % genomeLength] % genomeLength] / typeObj) + 1;//brain

                        NextGen(x, y, 4, true);
                    }
                    if (random.Next(4) == 0)
                    {
                        Obj[cX, cY, 1, random.Next(genomeLength)] = random.Next(genomeMax);
                        if (random.Next(4) == 0)
                        {
                            Obj[cX, cY, 0, type] = random.Next(1, 4);
                        }
                        if (random.Next(4) == 0)
                        {
                            Obj[cX, cY, 0, brain] = random.Next(0, 3);
                        }
                    }

                }
                else
                {
                    //DieCell(x, y);
                }
            }
            else
            {
                //DieCell(x, y);
            }
        }
        private void GenSentimentsInGlobal(int x, int y, bool genSent)
        {
            int[] chieldPos = CheckOnSentimentsInGlobal(x, y);
            int cX = chieldPos[0];
            int cY = chieldPos[1];
            haveStep = false;
            if (cY != -1 || cX != -1)
            {
                Obj[x, y, 0, energy] -= 150;
                if (Obj[x, y, 0, energy] > 150)
                {
                    Obj[x, y, 0, energy] /= 2;
                    Obj[x, y, 0, water] /= 2;

                    Obj[cX, cY, 0, R] = Obj[x, y, 0, R];//colorR
                    Obj[cX, cY, 0, G] = Obj[x, y, 0, G];//colorG
                    Obj[cX, cY, 0, B] = Obj[x, y, 0, B];//colorB
                    Obj[cX, cY, 0, type] = Obj[x, y, 0, type];//type
                    Obj[cX, cY, 0, brain] = Obj[x, y, 0, brain];//brain
                    Obj[cX, cY, 0, energy] = Obj[x, y, 0, energy];//energy
                    Obj[cX, cY, 0, water] = Obj[x, y, 0, water];//water
                    Obj[cX, cY, 0, light] = 0;//light
                    Obj[cX, cY, 0, rotate] = Obj[x, y, 0, rotate];//rotate
                    Obj[cX, cY, 0, activeGen] = 0;//activeGen
                    Obj[cX, cY, 0, previousBotX] = Obj[x, y, 0, previousBotX];//previousBotX
                    Obj[cX, cY, 0, previousBotY] = Obj[x, y, 0, previousBotY];//previousBotY
                    Obj[cX, cY, 0, nextBotX] = x;//nextBotX
                    Obj[cX, cY, 0, nextBotY] = y;//nextBotY
                    Obj[cX, cY, 0, old] = 0;

                    int PrevX = Obj[x, y, 0, previousBotX];
                    int PrevY = Obj[x, y, 0, previousBotY];

                    Obj[x, y, 0, previousBotX] = cX;
                    Obj[x, y, 0, previousBotY] = cY;

                    if (PrevX == -1 || PrevY == -1)
                    {
                        botZero[0] = cX;
                        botZero[1] = cY;
                    }
                    else
                    {
                        Obj[PrevX, PrevY, 0, nextBotX] = cX;
                        Obj[PrevX, PrevY, 0, nextBotY] = cY;
                    }
                    for (int g = 0; g < genomeLength; g++)
                    {
                        Obj[cX, cY, 1, g] = Obj[x, y, 1, g];
                    }

                    if (genSent)
                    {
                        int typeObj = genomeMax / 2;
                        Obj[cX, cY, 0, type] = (Obj[x, y, 1, Obj[x, y, 1, (activeGen + 2 + genomeLength) % genomeLength] % genomeLength] / typeObj) + 1;//type
                        Obj[cX, cY, 0, brain] = (Obj[x, y, 1, Obj[x, y, 1, (activeGen + 3 + genomeLength) % genomeLength] % genomeLength] / typeObj) + 1;//brain

                        NextGen(x, y, 4, true);
                    }
                    if (random.Next(4) == 0)
                    {
                        Obj[cX, cY, 1, random.Next(genomeLength)] = random.Next(genomeMax);
                        if (random.Next(4) == 0)
                        {
                            Obj[cX, cY, 0, type] = random.Next(1, 4);
                        }
                        if (random.Next(4) == 0)
                        {
                            Obj[cX, cY, 0, brain] = random.Next(0, 3);
                        }
                    }

                }
                else
                {
                    //DieCell(x, y);
                }
            }
            else
            {
                //DieCell(x, y);
            }
        }

        private void GenTurn(int x, int y)
        {
            RotateFunction(x, y);
            NextGen(x, y, 2, true);
        }
        private void GenTurnGlobal(int x, int y)
        {
            RotateFunctionGlobal(x, y);
            NextGen(x, y, 2, true);
        }

        private void GenLookFamily(int x, int y)
        {
            int types = 0;
            int[] chackIn = CheckOn(x, y);
            if (chackIn[1] < height)
            {
                if (CheckFamily(x, y, chackIn[0], chackIn[1]))
                {
                    types = 1;
                }
            }
            NextGen(x, y, types, false);
        }
        private void GenLookFamilyGlobal(int x, int y)
        {
            int types = 0;
            int[] chackIn = CheckOnGlobal(x, y);
            if (chackIn[1] < height)
            {
                if (CheckFamily(x, y, chackIn[0], chackIn[1]))
                {
                    types = 1;
                }
            }
            NextGen(x, y, types, false);
        }

        private void GenLookType(int x, int y)
        {
            int types = 0;
            int[] chackIn = CheckOn(x, y);
            if (chackIn[1] < height)
            {
                types = Obj[chackIn[0], chackIn[1], 0, type];
                types++;
            }
            NextGen(x, y, types, false);
        }
        private void GenLookTypeGlobal(int x, int y)
        {
            int types = 0;
            int[] chackIn = CheckOnGlobal(x, y);
            if (chackIn[1] < height)
            {
                types = Obj[chackIn[0], chackIn[1], 0, type];
                types++;
            }
            NextGen(x, y, types, false);
        }

        private void GenLookBrain(int x, int y)
        {
            int types = 0;
            int[] chackIn = CheckOn(x, y);
            if (chackIn[1] < height)
            {
                types = Obj[chackIn[0], chackIn[1], 0, brain];
            }
            NextGen(x, y, types, false);
        }
        private void GenLookBrainGlobal(int x, int y)
        {
            int types = 0;
            int[] chackIn = CheckOnGlobal(x, y);
            if (chackIn[1] < height)
            {
                types = Obj[chackIn[0], chackIn[1], 0, brain];
            }
            NextGen(x, y, types, false);
        }


        private void GenAttack(int x, int y)
        {
            int[] chackIn = CheckOn(x, y);
            int cX = chackIn[0];
            int cY = chackIn[1];
            int types = 0;
            Obj[x, y, 0, energy] -= 10;
            if (cY < height)
            {
                types = Obj[cX, cY, 0, type];

                if (types == -1)
                {
                    Obj[x, y, 0, energy] += Obj[cX, cY, 0, energy];
                    Obj[cX, cY, 0, type] = 0;
                    ChangeColor(x, y, 'R');
                }
                else if (Obj[cX, cY, 0, type] > 0)
                {
                    if (Obj[x, y, 0, water] >= Obj[cX, cY, 0, water])
                    {
                        Obj[x, y, 0, water] -= Obj[cX, cY, 0, water];
                        Obj[x, y, 0, energy] += 100 + (Obj[x, y, 0, energy] / 2);

                        KilledCell(cX, cY, x, y);
                    }
                    else
                    {
                        Obj[cX, cY, 0, water] -= Obj[x, y, 0, water];
                        Obj[x, y, 0, water] = 0;
                        if (Obj[x, y, 0, energy] * 2 >= Obj[cX, cY, 0, water])
                        {
                            Obj[x, y, 0, energy] += 100 + (Obj[cX, cY, 0, energy] / 2) - 2 * Obj[cX, cY, 0, water];
                            KilledCell(cX, cY, x, y);
                        }
                        else
                        {
                            Obj[cX, cY, 0, water] -= Obj[x, y, 0, energy] / 2;
                            Obj[x, y, 0, energy] -= 10;
                        }
                    }
                }
                if (CheckFamily(x, y, chackIn[0], chackIn[1]))
                {
                    types = 2;
                }
                if (Obj[chackIn[0], chackIn[1], 0, type] == -1)
                {
                    types = 3;
                }
            }

            NextGen(x, y, types, false);
        }
        private void GenAttackGlobal(int x, int y)
        {
            int[] chackIn = CheckOnGlobal(x, y);
            int cX = chackIn[0];
            int cY = chackIn[1];
            int types = 0;
            Obj[x, y, 0, energy] -= 10;
            if (cY < height)
            {
                types = Obj[cX, cY, 0, type];

                if (types == -1)
                {
                    Obj[x, y, 0, energy] += Obj[cX, cY, 0, energy];
                    Obj[cX, cY, 0, type] = 0;
                    ChangeColor(x, y, 'R');
                }
                else if (Obj[cX, cY, 0, type] > 0)
                {
                    if (Obj[x, y, 0, water] >= Obj[cX, cY, 0, water])
                    {
                        Obj[x, y, 0, water] -= Obj[cX, cY, 0, water];
                        Obj[x, y, 0, energy] += 100 + (Obj[x, y, 0, energy] / 2);

                        KilledCell(cX, cY, x, y);

                    }
                    else
                    {
                        Obj[cX, cY, 0, water] -= Obj[x, y, 0, water];
                        Obj[x, y, 0, water] = 0;
                        if (Obj[x, y, 0, energy] * 2 >= Obj[cX, cY, 0, water])
                        {
                            Obj[x, y, 0, energy] += 100 + (Obj[cX, cY, 0, energy] / 2) - 2 * Obj[cX, cY, 0, water];
                            KilledCell(cX, cY, x, y);
                        }
                        else
                        {
                            Obj[cX, cY, 0, water] -= Obj[x, y, 0, energy] / 2;
                            Obj[x, y, 0, energy] -= 10;
                        }
                    }
                }
                if (CheckFamily(x, y, chackIn[0], chackIn[1]))
                {
                    types = 2;
                }
                if (Obj[chackIn[0], chackIn[1], 0, type] == -1)
                {
                    types = 3;
                }
            }

            NextGen(x, y, types, false);
        }

        private void GenTransfer(int x, int y)
        {
            int[] chackIn = CheckOn(x, y);
            int cX = chackIn[0];
            int cY = chackIn[1];
            int types = 0;
            if (cY < height)
            {
                types = Obj[cX, cY, 0, type];
                if (Obj[cX, cY, 0, type] > 0)
                {
                    int borrowEnergy = (Obj[x, y, 0, energy] - Obj[cX, cY, 0, energy]) / 2;
                    int borrowWater = (Obj[x, y, 0, water] - Obj[x, y, 0, water]) / 2;
                    if (borrowEnergy > 0)
                    {
                        Obj[x, y, 0, energy] -= borrowEnergy;
                        Obj[cX, cY, 0, energy] += borrowEnergy;
                    }
                    if (borrowWater > 0)
                    {
                        Obj[x, y, 0, water] -= borrowWater;
                        Obj[cX, cY, 0, water] += borrowWater;
                    }
                }
                if (CheckFamily(x, y, chackIn[0], chackIn[1]))
                {
                    types = 2;
                }
                if (Obj[chackIn[0], chackIn[1], 0, type] == -1)
                {
                    types = 3;
                }
            }
            NextGen(x, y, types, false);
        }
        private void GenTransferGlobal(int x, int y)
        {
            int[] chackIn = CheckOnGlobal(x, y);
            int cX = chackIn[0];
            int cY = chackIn[1];
            int types = 0;
            if (cY < height)
            {
                types = Obj[cX, cY, 0, type];
                if (Obj[cX, cY, 0, type] > 0)
                {
                    int borrowEnergy = (Obj[x, y, 0, energy] - Obj[cX, cY, 0, energy]) / 2;
                    int borrowWater = (Obj[x, y, 0, water] - Obj[x, y, 0, water]) / 2;

                    if (borrowEnergy > 0)
                    {
                        Obj[x, y, 0, energy] -= borrowEnergy;
                        Obj[cX, cY, 0, energy] += borrowEnergy;
                    }
                    if (borrowWater > 0)
                    {
                        Obj[x, y, 0, water] -= borrowWater;
                        Obj[cX, cY, 0, water] += borrowWater;
                    }
                }
                if (CheckFamily(x, y, chackIn[0], chackIn[1]))
                {
                    types = 2;
                }
                if (Obj[chackIn[0], chackIn[1], 0, type] == -1)
                {
                    types = 3;
                }
            }
            NextGen(x, y, types, false);
        }

        private void GenTransferEnergy(int x, int y)
        {
            int[] chackIn = CheckOn(x, y);
            int cX = chackIn[0];
            int cY = chackIn[1];
            int types = 0;
            if (cY < height)
            {
                types = Obj[cX, cY, 0, type];
                if (Obj[cX, cY, 0, type] > 0)
                {
                    int borrowEnergy = (Obj[x, y, 0, energy] - Obj[cX, cY, 0, energy]) / 2;
                    if (borrowEnergy > 0)
                    {
                        Obj[x, y, 0, energy] -= borrowEnergy;
                        Obj[cX, cY, 0, energy] += borrowEnergy;
                    }
                }
                if (CheckFamily(x, y, chackIn[0], chackIn[1]))
                {
                    types = 2;
                }
                if (Obj[chackIn[0], chackIn[1], 0, type] == -1)
                {
                    types = 3;
                }
            }
            NextGen(x, y, types, false);
        }
        private void GenTransferEnergyGlobal(int x, int y)
        {
            int[] chackIn = CheckOnGlobal(x, y);
            int cX = chackIn[0];
            int cY = chackIn[1];
            int types = 0;
            if (cY < height)
            {
                types = Obj[cX, cY, 0, type];
                if (Obj[cX, cY, 0, type] > 0)
                {
                    int borrowEnergy = (Obj[x, y, 0, energy] - Obj[cX, cY, 0, energy]) / 2;
                    if (borrowEnergy > 0)
                    {
                        Obj[x, y, 0, energy] -= borrowEnergy;
                        Obj[cX, cY, 0, energy] += borrowEnergy;
                    }
                }
                if (CheckFamily(x, y, chackIn[0], chackIn[1]))
                {
                    types = 2;
                }
                if (Obj[chackIn[0], chackIn[1], 0, type] == -1)
                {
                    types = 3;
                }
            }
            NextGen(x, y, types, false);
        }

        private void GenTransferWater(int x, int y)
        {
            int[] chackIn = CheckOn(x, y);
            int cX = chackIn[0];
            int cY = chackIn[1];
            int types = 0;
            if (cY < height)
            {
                types = Obj[cX, cY, 0, type];
                if (Obj[cX, cY, 0, type] > 0)
                {
                    int borrowWater = (Obj[x, y, 0, water] - Obj[x, y, 0, water]) / 2;
                    if (borrowWater > 0)
                    {
                        Obj[x, y, 0, water] -= borrowWater;
                        Obj[cX, cY, 0, water] += borrowWater;
                    }
                }
                if (CheckFamily(x, y, chackIn[0], chackIn[1]))
                {
                    types = 2;
                }
                if (Obj[chackIn[0], chackIn[1], 0, type] == -1)
                {
                    types = 3;
                }
            }
            NextGen(x, y, types, false);
        }
        private void GenTransferWaterGlobal(int x, int y)
        {
            int[] chackIn = CheckOnGlobal(x, y);
            int cX = chackIn[0];
            int cY = chackIn[1];
            int types = 0;
            if (cY < height)
            {
                types = Obj[cX, cY, 0, type];
                if (Obj[cX, cY, 0, type] > 0)
                {
                    int borrowWater = (Obj[x, y, 0, water] - Obj[x, y, 0, water]) / 2;
                    if (borrowWater > 0)
                    {
                        Obj[x, y, 0, water] -= borrowWater;
                        Obj[cX, cY, 0, water] += borrowWater;
                    }
                }
                if (CheckFamily(x, y, chackIn[0], chackIn[1]))
                {
                    types = 2;
                }
                if (Obj[chackIn[0], chackIn[1], 0, type] == -1)
                {
                    types = 3;
                }
            }
            NextGen(x, y, types, false);
        }


        private void GenShare(int x, int y)
        {
            int[] chackIn = CheckOn(x, y);
            int cX = chackIn[0];
            int cY = chackIn[1];
            int types = 0;

            if (cY < height)
            {
                types = Obj[cX, cY, 0, type];
                if (Obj[cX, cY, 0, type] > 0)
                {
                    int addEnergy = Obj[x, y, 0, energy] / 4;
                    int addWater = Obj[x, y, 0, water] / 4;

                    Obj[x, y, 0, energy] -= addEnergy;
                    Obj[cX, cY, 0, energy] += addEnergy;

                    Obj[x, y, 0, water] -= addWater;
                    Obj[cX, cY, 0, water] += addWater;
                }
                if (CheckFamily(x, y, chackIn[0], chackIn[1]))
                {
                    types = 2;
                }
                if (Obj[chackIn[0], chackIn[1], 0, type] == -1)
                {
                    types = 3;
                }
            }
            NextGen(x, y, types, false);
        }
        private void GenShareGlobal(int x, int y)
        {
            int[] chackIn = CheckOnGlobal(x, y);
            int cX = chackIn[0];
            int cY = chackIn[1];
            int types = 0;

            if (cY < height)
            {
                types = Obj[cX, cY, 0, type];
                if (Obj[cX, cY, 0, type] > 0)
                {
                    int addEnergy = Obj[x, y, 0, energy] / 4;
                    int addWater = Obj[x, y, 0, water] / 4;

                    Obj[x, y, 0, energy] -= addEnergy;
                    Obj[cX, cY, 0, energy] += addEnergy;

                    Obj[x, y, 0, water] -= addWater;
                    Obj[cX, cY, 0, water] += addWater;
                }
                if (CheckFamily(x, y, chackIn[0], chackIn[1]))
                {
                    types = 2;
                }
                if (Obj[chackIn[0], chackIn[1], 0, type] == -1)
                {
                    types = 3;
                }
            }
            NextGen(x, y, types, false);
        }

        private void GenShareEnergy(int x, int y)
        {
            int[] chackIn = CheckOn(x, y);
            int cX = chackIn[0];
            int cY = chackIn[1];
            int types = 0;

            if (cY < height)
            {
                types = Obj[cX, cY, 0, type];
                if (Obj[cX, cY, 0, type] > 0)
                {
                    int addEnergy = Obj[x, y, 0, energy] / 4;

                    Obj[x, y, 0, energy] -= addEnergy;
                    Obj[cX, cY, 0, energy] += addEnergy;
                }
                if (CheckFamily(x, y, chackIn[0], chackIn[1]))
                {
                    types = 2;
                }
                if (Obj[chackIn[0], chackIn[1], 0, type] == -1)
                {
                    types = 3;
                }
            }
            NextGen(x, y, types, false);
        }
        private void GenShareEnergyGlobal(int x, int y)
        {
            int[] chackIn = CheckOnGlobal(x, y);
            int cX = chackIn[0];
            int cY = chackIn[1];
            int types = 0;

            if (cY < height)
            {
                types = Obj[cX, cY, 0, type];
                if (Obj[cX, cY, 0, type] > 0)
                {
                    int addEnergy = Obj[x, y, 0, energy] / 4;

                    Obj[x, y, 0, energy] -= addEnergy;
                    Obj[cX, cY, 0, energy] += addEnergy;
                }
                if (CheckFamily(x, y, chackIn[0], chackIn[1]))
                {
                    types = 2;
                }
                if (Obj[chackIn[0], chackIn[1], 0, type] == -1)
                {
                    types = 3;
                }
            }
            NextGen(x, y, types, false);
        }

        private void GenShareWater(int x, int y)
        {
            int[] chackIn = CheckOn(x, y);
            int cX = chackIn[0];
            int cY = chackIn[1];
            int types = 0;

            if (cY < height)
            {
                types = Obj[cX, cY, 0, type];
                if (Obj[cX, cY, 0, type] > 0)
                {
                    int addWater = Obj[x, y, 0, water] / 4;

                    Obj[x, y, 0, water] -= addWater;
                    Obj[cX, cY, 0, water] += addWater;
                }
                if (CheckFamily(x, y, chackIn[0], chackIn[1]))
                {
                    types = 2;
                }
                if (Obj[chackIn[0], chackIn[1], 0, type] == -1)
                {
                    types = 3;
                }
            }
            NextGen(x, y, types, false);
        }
        private void GenShareWaterGlobal(int x, int y)
        {
            int[] chackIn = CheckOnGlobal(x, y);
            int cX = chackIn[0];
            int cY = chackIn[1];
            int types = 0;

            if (cY < height)
            {
                types = Obj[cX, cY, 0, type];
                if (Obj[cX, cY, 0, type] > 0)
                {
                    int addWater = Obj[x, y, 0, water] / 4;

                    Obj[x, y, 0, water] -= addWater;
                    Obj[cX, cY, 0, water] += addWater;
                }
                if (CheckFamily(x, y, chackIn[0], chackIn[1]))
                {
                    types = 2;
                }
                if (Obj[chackIn[0], chackIn[1], 0, type] == -1)
                {
                    types = 3;
                }
            }
            NextGen(x, y, types, false);
        }

        private void GenLookEnergy(int x, int y)
        {
            int take = genomeMax / 1000;
            if (Obj[x, y, 0, energy] > Obj[x, y, 0, (activeGen + 1 + genomeLength) % genomeLength] * take)
                NextGen(x, y, 2, false);
            else
                NextGen(x, y, 3, false);
        }
        private void GenLookWater(int x, int y)
        {
            int take = genomeMax / 1000;
            if (Obj[x, y, 0, water] > Obj[x, y, 0, (activeGen + 1 + genomeLength) % genomeLength] * take)
                NextGen(x, y, 2, false);
            else
                NextGen(x, y, 3, false);
        }

        private void GenLookAround(int x, int y)
        {
            int around = CheckingAround(x, y);
            around /= 3;
            NextGen(x, y, around, false);
        }

        private void RotateFunction(int x, int y)
        {
            int rotates = (Obj[x, y, 0, rotate] + Obj[x, y, 1, (Obj[x, y, 0, activeGen] + 1 + genomeLength) % genomeLength] + 8) % 8;
            Obj[x, y, 0, rotate] = rotates;
        }
        private void RotateFunctionGlobal(int x, int y)
        {
            int rotates = (Obj[x, y, 1, (Obj[x, y, 0, activeGen] + 1 + genomeLength) % genomeLength] + 8) % 8;
            Obj[x, y, 0, rotate] = rotates;
        }

        private void ChangeColor(int x, int y, char color)
        {
            if (color == 'R')
            {
                if (Obj[x, y, 0, R] < 210)
                    Obj[x, y, 0, R] += 15;
                if (Obj[x, y, 0, G] > 14)
                    Obj[x, y, 0, G] -= 15;
                if (Obj[x, y, 0, B] > 14)
                    Obj[x, y, 0, B] -= 15;
            }
            if (color == 'G')
            {
                if (Obj[x, y, 0, R] > 14)
                    Obj[x, y, 0, R] -= 15;
                if (Obj[x, y, 0, G] < 210)
                    Obj[x, y, 0, G] += 15;
                if (Obj[x, y, 0, B] > 14)
                    Obj[x, y, 0, B] -= 15;

            }
            if (color == 'B')
            {
                if (Obj[x, y, 0, R] > 14)
                    Obj[x, y, 0, R] -= 15;
                if (Obj[x, y, 0, G] > 14)
                    Obj[x, y, 0, G] -= 15;
                if (Obj[x, y, 0, B] < 210)
                    Obj[x, y, 0, B] += 15;

            }
        }

        private int[] CheckOn(int X, int Y)
        {
            int rotates;
            int[] moveIn = new int[2];
            rotates = (Obj[X, Y, 0, rotate] + Obj[X, Y, 0, (Obj[X, Y, 0, activeGen] + 1 + genomeLength) % genomeLength] + 8) % 8;

            int x = 0, y = 0;
            if (rotates == 0)
            {
                x = X;
                y = Y - 1;
            }
            else if (rotates == 1)
            {
                x = X + 1;
                y = Y - 1;
            }
            else if (rotates == 2)
            {
                x = X + 1;
                y = Y;
            }
            else if (rotates == 3)
            {
                x = X + 1;
                y = Y + 1;
            }
            else if (rotates == 4)
            {
                x = X;
                y = Y + 1;
            }
            else if (rotates == 5)
            {
                x = X - 1;
                y = Y + 1;
            }
            else if (rotates == 6)
            {
                x = X - 1;
                y = Y;
            }
            else if (rotates == 7)
            {
                x = X - 1;
                y = Y - 1;
            }
            x = (x + width) % width;

            if (y < 0)
            {
                y = height + 1;
            }
            moveIn[0] = x;
            moveIn[1] = y;

            return moveIn;
        }
        private int[] CheckOnGlobal(int X, int Y)
        {
            int rotates;
            int[] moveIn = new int[2];
            rotates = (Obj[X, Y, 0, (Obj[X, Y, 0, activeGen] + 1 + genomeLength) % genomeLength] + 8) % 8;

            int x = 0, y = 0;
            if (rotates == 0)
            {
                x = X;
                y = Y - 1;
            }
            else if (rotates == 1)
            {
                x = X + 1;
                y = Y - 1;
            }
            else if (rotates == 2)
            {
                x = X + 1;
                y = Y;
            }
            else if (rotates == 3)
            {
                x = X + 1;
                y = Y + 1;
            }
            else if (rotates == 4)
            {
                x = X;
                y = Y + 1;
            }
            else if (rotates == 5)
            {
                x = X - 1;
                y = Y + 1;
            }
            else if (rotates == 6)
            {
                x = X - 1;
                y = Y;
            }
            else if (rotates == 7)
            {
                x = X - 1;
                y = Y - 1;
            }
            x = (x + width) % width;

            if (y < 0)
            {
                y = height + 1;
            }
            moveIn[0] = x;
            moveIn[1] = y;

            return moveIn;
        }

        private int CheckingAround(int X, int Y)
        {
            int moreObj = 0;

            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    int sX = (X + x + width) % width;
                    int sY = Y + y;
                    if (sY < height && sY >= 0)
                    {
                        if (Obj[sX, sY, 0, type] > 0 || Obj[sX, sY, 0, type] == -1)
                        {
                            moreObj++;
                        }
                    }
                }
            }
            return moreObj;
        }
        private int CheckingAroundGravityType(int X, int Y)
        {
            int moreObj = 0;

            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    if (x != 0 && y != 1)
                    {
                        int sX = (X + x + width) % width;
                        int sY = Y + y;
                        if (sY < height && sY >= 0)
                        {
                            switch (Obj[X, Y, 0, type])
                            {
                                case 1:
                                    {
                                        switch (Obj[sX, sY, 0, type])
                                        {
                                            case 1:
                                                moreObj += 1;
                                                break;
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        switch (Obj[sX, sY, 0, type])
                                        {
                                            case 1:
                                                moreObj += 2;
                                                break;
                                            case 2:
                                                moreObj += 1;
                                                break;
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        switch (Obj[sX, sY, 0, type])
                                        {
                                            case 1:
                                                moreObj += 3;
                                                break;
                                            case 2:
                                                moreObj += 2;
                                                break;
                                            case 3:
                                                moreObj += 1;
                                                break;
                                        }
                                        break;
                                    }
                                default:
                                    break;
                            }
                            /*if (Obj[sX, sY, 0, type] == -1)
                            {
                                moreObj += 99;
                            }*/

                        }
                    }
                }
            }
            return moreObj;
        }
        private int CheckingAroundGravityLight(int X, int Y)
        {
            int moreObj = 0;

            for (int x = -1; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    if (x != 0 && y != 1)
                    {
                        int sX = (X + x + width) % width;
                        int sY = Y + y;
                        if (sY < height && sY >= 0)
                        {
                            switch (Obj[sX, sY, 0, type])
                            {
                                case 1:
                                    moreObj += 3;
                                    break;
                                case 2:
                                    moreObj += 2;
                                    break;
                                case 3:
                                    moreObj += 1;
                                    break;
                            }

                        }
                    }
                }
            }
            return moreObj;
        }
        private int CheckingAroundGravityWater(int X, int Y)
        {
            int moreObj = 0;

            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 0; y++)
                {
                    if (x != 0 && y != 1)
                    {
                        int sX = (X + x + width) % width;
                        int sY = Y + y;
                        if (sY < height && sY >= 0)
                        {
                            if (Obj[sX, sY, 0, water] >= 0 && Obj[sX, sY, 0, water] < 250)
                            {
                                moreObj += 1;
                            }
                            else if (Obj[sX, sY, 0, water] >= 250 && Obj[sX, sY, 0, water] < 500)
                            {
                                moreObj += 2;
                            }
                            else if (Obj[sX, sY, 0, water] >= 500 && Obj[sX, sY, 0, water] > 750)
                            {
                                moreObj += 3;
                            }
                            else if (Obj[sX, sY, 0, water] >= 750)
                            {
                                moreObj += 4;
                            }
                        }
                    }
                }
            }
            return moreObj;
        }


        private int[] CheckOnSentiments(int X, int Y)
        {
            int rotates = random.Next(8);
            int[] FreePosition = new int[] { -1, -1 };

            for (int r = 0; r < 8; r++)
            {
                rotates = (rotates + 1 + 8) % 8;
                int x = 0, y = 0;
                if (rotates == 0)
                {
                    x = X;
                    y = Y - 1;
                }
                else if (rotates == 1)
                {
                    x = X + 1;
                    y = Y - 1;
                }
                else if (rotates == 2)
                {
                    x = X + 1;
                    y = Y;
                }
                else if (rotates == 3)
                {
                    x = X + 1;
                    y = Y + 1;
                }
                else if (rotates == 4)
                {
                    x = X;
                    y = Y + 1;
                }
                else if (rotates == 5)
                {
                    x = X - 1;
                    y = Y + 1;
                }
                else if (rotates == 6)
                {
                    x = X - 1;
                    y = Y;
                }
                else if (rotates == 7)
                {
                    x = X - 1;
                    y = Y - 1;
                }
                x = (x + width) % width;

                if (y < height && y >= 0)
                {
                    if (Obj[x, y, 0, type] == 0)
                    {
                        FreePosition[0] = x;
                        FreePosition[1] = y;
                        return FreePosition;
                    }
                }
            }
            return FreePosition;
        }
        private int[] CheckOnSentimentsIn(int X, int Y)
        {
            int rotates = (Obj[X, Y, 0, rotate] + Obj[X, Y, 1, (Obj[X, Y, 0, activeGen] + 1 + genomeLength) % genomeLength] + 8) % 8;
            int[] FreePosition = new int[] { -1, -1 };
            int x = 0, y = 0;
            if (rotates == 0)
            {
                x = X;
                y = Y - 1;
            }
            else if (rotates == 1)
            {
                x = X + 1;
                y = Y - 1;
            }
            else if (rotates == 2)
            {
                x = X + 1;
                y = Y;
            }
            else if (rotates == 3)
            {
                x = X + 1;
                y = Y + 1;
            }
            else if (rotates == 4)
            {
                x = X;
                y = Y + 1;
            }
            else if (rotates == 5)
            {
                x = X - 1;
                y = Y + 1;
            }
            else if (rotates == 6)
            {
                x = X - 1;
                y = Y;
            }
            else if (rotates == 7)
            {
                x = X - 1;
                y = Y - 1;
            }
            x = (x + width) % width;

            if (y < height && y >= 0)
            {
                if (Obj[x, y, 0, type] == 0)
                {
                    FreePosition[0] = x;
                    FreePosition[1] = y;
                    return FreePosition;
                }
            }
            return FreePosition;
        }
        private int[] CheckOnSentimentsInGlobal(int X, int Y)
        {
            int rotates = (Obj[X, Y, 1, (Obj[X, Y, 0, activeGen] + 1 + genomeLength) % genomeLength] + 8) % 8;
            int[] FreePosition = new int[] { -1, -1 };
            int x = 0, y = 0;
            if (rotates == 0)
            {
                x = X;
                y = Y - 1;
            }
            else if (rotates == 1)
            {
                x = X + 1;
                y = Y - 1;
            }
            else if (rotates == 2)
            {
                x = X + 1;
                y = Y;
            }
            else if (rotates == 3)
            {
                x = X + 1;
                y = Y + 1;
            }
            else if (rotates == 4)
            {
                x = X;
                y = Y + 1;
            }
            else if (rotates == 5)
            {
                x = X - 1;
                y = Y + 1;
            }
            else if (rotates == 6)
            {
                x = X - 1;
                y = Y;
            }
            else if (rotates == 7)
            {
                x = X - 1;
                y = Y - 1;
            }
            x = (x + width) % width;

            if (y < height && y >= 0)
            {
                if (Obj[x, y, 0, type] == 0)
                {
                    FreePosition[0] = x;
                    FreePosition[1] = y;
                    return FreePosition;
                }
            }
            return FreePosition;
        }

        private bool CheckFamily(int X, int Y, int x, int y)
        {
            int notFamily = 0;
            switch (Obj[X, Y, 0, brain])
            {
                case 0:
                    for (int i = 0; i < genomeLength; i++)
                    {
                        if (Obj[X, Y, 1, i] != Obj[x, y, 1, i])
                        {
                            notFamily++;
                            if (notFamily > 1)
                            {
                                return false;
                            }
                        }
                    }
                    break;
                case 1:
                    for (int i = genomeLength / 2; i < genomeLength; i++)
                    {
                        if (Obj[X, Y, 1, i] != Obj[x, y, 1, i])
                        {
                            notFamily++;
                            if (notFamily > 1)
                            {
                                return false;
                            }
                        }
                    }
                    break;
                case 2:
                    for (int i = genomeLength / 4 * 3; i < genomeLength; i++)
                    {
                        if (Obj[X, Y, 1, i] != Obj[x, y, 1, i])
                        {
                            notFamily++;
                            if (notFamily > 1)
                            {
                                return false;
                            }
                        }
                    }
                    break;
            }
            return false;
        }
        private void CorrectEW(int x, int y)
        {
            if (Obj[x, y, 0, type] >= 1)
            {
                if (Obj[x, y, 0, energy] > 1000)
                {
                    Obj[x, y, 0, energy] = 1000;
                }
                if (Obj[x, y, 0, water] > 1000)
                {
                    Obj[x, y, 0, water] = 1000;
                }
            }
        }
    }
}
