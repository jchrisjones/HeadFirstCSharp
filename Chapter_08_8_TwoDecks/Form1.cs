﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_08_8_TwoDecks
{
    public partial class Form1 : Form
    {
        Deck deck1, deck2;
        List<Card> initialCards;
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            ResetDeck(1);
            ResetDeck(2);
            RedrawDeck(1);
            RedrawDeck(2);
        }

        //========== Events ===========//
        private void moveToDeck2_Click(object sender, EventArgs e)
        {
            if (deck1ListBox.SelectedIndex >= 0)
                if (deck1.Count > 0)
                    deck2.Add(deck1.Deal(deck1ListBox.SelectedIndex));            
            RedrawDeck(1);
            RedrawDeck(2);
        }

        private void moveToDeck1_Click(object sender, EventArgs e)
        {
            if (deck2ListBox.SelectedIndex >= 0)
                if (deck2.Count > 0)
                    deck1.Add(deck2.Deal(deck2ListBox.SelectedIndex));   
            RedrawDeck(1);
            RedrawDeck(2);
        }

        private void reset1_Click(object sender, EventArgs e)
        {
            ResetDeck(1);
            RedrawDeck(1);
        }

        private void reset2_Click(object sender, EventArgs e)
        {
            ResetDeck(2);
            RedrawDeck(2);
        }

        private void suffle1_Click(object sender, EventArgs e)
        {
            deck1.Shuffle();
            RedrawDeck(1);
        }

        private void shuffle2_Click(object sender, EventArgs e)
        {
            deck2.Shuffle();
            RedrawDeck(2);
        }

        //========== Methods ===========//

        private void ResetDeck(int DeckNumber)
        {
            if (DeckNumber == 1)
            {
                int numberOfCards = rand.Next(1, 11);
                deck1 = new Deck(new Card[] { });
                for (int i = 0; i < numberOfCards; i++)
                    deck1.Add(new Card((Suits)rand.Next(4),
                                       (Values)rand.Next(1, 14)));
                deck1.Sort();
            }
            else
            {
                deck2 = new Deck();
            }
        }

        private void RedrawDeck(int DeckNumber)
        {
            if(DeckNumber == 1)
            {
                deck1ListBox.Items.Clear();
                foreach (string cardName in deck1.GetCardNames())
                    deck1ListBox.Items.Add(cardName);
                deck1Label.Text = "Deck #1 (" + deck1.Count + " cards)";
            }
            else
            {
                deck2ListBox.Items.Clear();
                foreach (string cardName in deck2.GetCardNames())
                    deck2ListBox.Items.Add(cardName);
                deck2Label.Text = "Deck #2 (" + deck2.Count + " cards)";
            }
        }

    }
}
