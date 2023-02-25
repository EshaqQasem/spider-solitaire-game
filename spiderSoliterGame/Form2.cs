using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace spiderSoliterGame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            this.cardsStacks = new cardsStack[10];

            for (int i = 0; i < 10; i++)
            {
                this.cardsStacks[i] = new cardsStack();
                this.cardsStacks[i].Size = new System.Drawing.Size(85, 347);
                this.cardsStacks[i].Location = new System.Drawing.Point(this.Width-50- ((i+1) * (cardsStacks[i].Width + 10)), 46);
                this.cardsStacks[i].AllowDrop = true;
                this.cardsStacks[i].DragEnter += cardsStack_DragEnter;
                this.cardsStacks[i].DragDrop += cardsStack_DragDrop;
                this.cardsStacks[i].DragOver += Form2_DragOver;
                this.cardsStacks[i].Tag = i;
                this.cardsStacks[i].Anchor = AnchorStyles.Top;
                this.Controls.Add(cardsStacks[i]);

            }

            this.dragedCardsVeiw = new cardsStack();
            this.dragedCardsVeiw.Size = new System.Drawing.Size(90, 120);
            winStack = new WinStack();
            winStack.Location = new Point(this.Width-300, this.Height - 150);
            this.Controls.Add(winStack);
            winStack.BringToFront();
            winStack.Anchor = AnchorStyles.Bottom;
        }
        WinStack winStack;
        private void Form2_Load(object sender, EventArgs e)
        {
           // InitializeGame();

        }

        void reGame()
        {
            foreach (cardsStack cs in cardsStacks)
            {
                cs.Controls.Clear();
                cs.CardVeiwTop1 = 0;
            }
            panelUnPlayedCards.Controls.Clear();
            winStack.Controls.Clear();
            UndoStack.Clear();
            if(savedGame.Exists)
               savedGame.Delete();
            InitializeGame();
        }
        private void InitializeGame()
        {
           
            unPlayedCards = new Deck(104);
            unPlayedCards.Shuffle();
            //  unPlayedCards.Shuffle();
            // unPlayedCards.Shuffle();
            for (int i = 0; i < 54; i++)
            {
                Card temp = unPlayedCards.Top;
                bool c = true;
                if (i >= 44)
                    c = false;

                cardsStacks[i % 10].Add(temp, c);
                cardsStacks[i % 10].Controls[0].MouseDown += Form2_MouseDown;
                cardsStacks[i % 10].Controls[0].Tag = i % 10;

            }

            initUnPlayedCardView();
        }

        void initUnPlayedCardView(int pc=3)
        {

            for (int i = 0; i < pc; i++)
            {
                PictureBox tmp = new PictureBox();

                tmp.Click += this.panelUnPlayedCards_Click;
                tmp.Size = new System.Drawing.Size(75, 100);
                tmp.Left = i * 10;

                tmp.SizeMode = PictureBoxSizeMode.StretchImage;
                tmp.Image = CardVeiw.backImage;
                tmp.SendToBack();

                panelUnPlayedCards.Controls.Add(tmp);

            }

            panelUnPlayedCards.BringToFront();


        }

        private void cardsStack_DragDrop(object sender, DragEventArgs e)
        {
            cardsStack tmp = (cardsStack)sender;
            Card firstCard = ((CardVeiw)dragedCardsVeiw.Controls[dragedCardsVeiw.Controls.Count - 1]).Card;
            if (!tmp.DragOn(firstCard))
            {
                tmp = cardsStacks[cardStackIndex];
            }
            int movedCardCount = dragedCardsVeiw.Controls.Count;
            for (int i = movedCardCount - 1; i >= 0; i--)
            {
                tmp.Add(((CardVeiw)dragedCardsVeiw.Controls[i]).Card, false);
                tmp.Controls[0].Tag = (int)tmp.Tag;
                tmp.Controls[0].MouseDown += Form2_MouseDown;
            }

            if (tmp != cardsStacks[cardStackIndex])
            {
                UndoStack.Push(new UndoRedo(cardsStacks[cardStackIndex], tmp, movedCardCount));

                try
                {
                    if (tmp.hasFullStack())
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            tmp.Controls.RemoveAt(0);
                        }

                        tmp.Clip();
                        UndoStack.Clear();
                        winStack.Add();
                        if (winStack.Controls.Count == 8)
                        {
                            MessageBox.Show("WIN THE GAME");
                            this.reGame();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (((cardsStack)cardsStacks[cardStackIndex]).Controls.Count > 0 && ((CardVeiw)((cardsStack)cardsStacks[cardStackIndex]).Controls[0]).Cliped)
            {
                ((cardsStack)cardsStacks[cardStackIndex]).Clip();
                UndoStack.Peek().Cliped = true;
            }
            dragedCardsVeiw.Controls.Clear();
            this.Controls.Remove(dragedCardsVeiw);


        }

        private void cardsStack_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
            //  dragedCardsVeiw.Left = e.X - this.Left;// ((Control)sender).Left;
            //dragedCardsVeiw.Top = e.Y - this.Top;// ((Control)sender).Top;

        }

        cardsStack[] cardsStacks;
        Deck unPlayedCards;// new Stack<Card>();
       

        cardsStack dragedCardsVeiw;
        int cardStackIndex;
        void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                CardVeiw cv = (CardVeiw)sender;
                cardStackIndex = (int)cv.Tag;
                int i = this.cardsStacks[cardStackIndex].Controls.IndexOf(cv);
                if (this.cardsStacks[cardStackIndex].Dragable(i))
                {

                    for (; i >= 0; i--)
                    {
                        dragedCardsVeiw.Add(((CardVeiw)this.cardsStacks[cardStackIndex].Controls[i]).Card, false);
                        this.cardsStacks[cardStackIndex].Controls.RemoveAt(i);
                    }
                    this.Controls.Add(dragedCardsVeiw);
                    dragedCardsVeiw.BringToFront();
                    dragedCardsVeiw.Refresh();
                    this.DoDragDrop(";;", DragDropEffects.All);
                }

            }

        }


        private void panelUnPlayedCards_Click(object sender, EventArgs e)
        {

            if (unPlayedCards.CardCount > 0)
            {
                for (int i = 0; i < 10; i++)
                {

                    Card temp = unPlayedCards.Top;

                    cardsStacks[i % 10].Add(temp, false);
                    cardsStacks[i % 10].Controls[0].MouseDown += Form2_MouseDown;
                    cardsStacks[i % 10].Controls[0].Tag = i % 10;


                }

            }


            if (unPlayedCards.CardCount == 0)
            {
                panelUnPlayedCards.Controls.Clear();
            }
        }

        private void Form2_DragOver(object sender, DragEventArgs e)
        {
            dragedCardsVeiw.Left = this.Width -(e.X - this.Left)-50;
            dragedCardsVeiw.Top = e.Y - this.Top - 15;

        }

        private void Form2_DragDrop(object sender, DragEventArgs e)
        {
            for (int i = dragedCardsVeiw.Controls.Count - 1; i >= 0; i--)
            {
                cardsStacks[cardStackIndex].Add(((CardVeiw)dragedCardsVeiw.Controls[i]).Card, false);
                cardsStacks[cardStackIndex].Controls[0].Tag = cardStackIndex;
                cardsStacks[cardStackIndex].Controls[0].MouseDown += Form2_MouseDown;
            }

            dragedCardsVeiw.Controls.Clear();
            this.Controls.Remove(dragedCardsVeiw);
        }

        private void Form2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;

        }

        private void newGame_Click(object sender, EventArgs e)
        {
           reGame();
        }

        private void Form2_DragLeave(object sender, EventArgs e)
        {
            //  Form2_DragDrop(null, null);

        }
        Stack<UndoRedo> UndoStack = new Stack<UndoRedo>();

        private void Undo_Click(object sender, EventArgs e)
        {
            if (UndoStack.Count > 0)
            {
                UndoRedo ur = UndoStack.Pop();
                if (ur.Cliped)
                    ((CardVeiw)ur.FromStack.Controls[0]).Clip();
                for (int i = ur.CardCount - 1; i >= 0; i--)
                {
                    ur.FromStack.Add(((CardVeiw)ur.ToStack.Controls[i]).Card, false);
                    ur.FromStack.Controls[0].Tag = (int)ur.FromStack.Tag;
                    ur.FromStack.Controls[0].MouseDown += Form2_MouseDown;
                    ur.ToStack.Controls.RemoveAt(i);
                    //  ur.FromStack.Controls[0].Tag = ur.FromStack.Tag;
                }
            }
        }

        void SaveGame()
        {
            FileStream file = new FileStream(savedGame.FullName, FileMode.Create);
            for (int i = 0; i < cardsStacks.Length; i++)
            {
                file.WriteByte((byte)cardsStacks[i].Controls.Count);
                for (int j = cardsStacks[i].Controls.Count - 1; j >= 0; j--)
                {
                    file.WriteByte((byte)((CardVeiw)cardsStacks[i].Controls[j]).Card.CardType);
                    file.WriteByte((byte)(((CardVeiw)cardsStacks[i].Controls[j]).Cliped ? 1 : 0));

                }

            }
            file.WriteByte((byte)unPlayedCards.CardCount);
            for (int i = 0; i < unPlayedCards.CardCount; i++)
            {
                file.WriteByte((byte)unPlayedCards[i].CardType);
            }
            file.WriteByte((byte)this.winStack.Controls.Count);
            file.Close();
        }
        static FileInfo savedGame = new FileInfo(Application.StartupPath+ "\\savedGame.dat"); 

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(this,"ماذا تريد ان تفعل في اللعبة الحالية؟", "انهاء اللعبة", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Cancel)
                e.Cancel = true;
            else if (dr == DialogResult.Yes)
            {
                SaveGame();
            }
            else
            {
                if (savedGame.Exists)
                    savedGame.Delete();
            }


        }

        private void Form2_Shown(object sender, EventArgs e)
        {

            if (savedGame.Exists)
            {
                DialogResult continueGame = MessageBox.Show(this, "هل ترغب بمتابعة اللعبة المحفوضة؟", "تم العثور على لعبة محفوضة", MessageBoxButtons.YesNo);
                if (continueGame == DialogResult.Yes)
                {
                    FileStream file = new FileStream(savedGame.FullName, FileMode.Open);
                    for (int i = 0; i < cardsStacks.Length; i++)
                    {
                        int stackLength = file.ReadByte();

                        for (int j = 0; j < stackLength; j++)
                        {
                            int cardTpye = file.ReadByte();
                            bool cardCliped = file.ReadByte() == 1 ? true : false;
                            cardsStacks[i].Add(new Card((CardType)cardTpye), cardCliped);
                            cardsStacks[i].Controls[0].MouseDown += Form2_MouseDown;
                            cardsStacks[i].Controls[0].Tag = i;
                        }

                    }
                    int unPlayedCardCount = file.ReadByte();
                    unPlayedCards = new Deck(unPlayedCardCount, false);
                    for (int i = 0; i < unPlayedCardCount; i++)
                    {
                        unPlayedCards[i] = new Card((CardType)file.ReadByte());

                    }
                    int winStackCount = file.ReadByte();
                    for (int i = 0; i < winStackCount; i++)
                        winStack.Add();
                    file.Close();
                    initUnPlayedCardView(unPlayedCardCount > 0 ? 3 : 0);
                }
                else
                {
                    InitializeGame();
                }
            }
            else
            {
                InitializeGame();
            }
            
        }
    }
        class UndoRedo
        {
            public UndoRedo(cardsStack fIndex, cardsStack tIndex, int CardCount)
            {
                fromStack = fIndex;
                toStack = tIndex;
                this.CardCount = CardCount;
                this.Cliped = false;
            }
            bool cliped;

            public bool Cliped
            {
                get { return cliped; }
                set { cliped = value; }
            }
            int cardCount;

            public int CardCount
            {
                get { return cardCount; }
                set { cardCount = value; }
            }
            cardsStack fromStack;

            public cardsStack FromStack
            {
                get { return fromStack; }
                set { fromStack = value; }
            }
            cardsStack toStack;

            public cardsStack ToStack
            {
                get { return toStack; }
                set { toStack = value; }
            }


        }

       
    
}
