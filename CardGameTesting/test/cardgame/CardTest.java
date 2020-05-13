/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cardgame;

import javax.swing.DefaultListModel;
import javax.swing.JButton;
import javax.swing.JLabel;
import org.junit.Test;
import static org.junit.Assert.*;
import org.junit.BeforeClass;

/**
 *
 * @author erikg
 */
public class CardTest {
    Card aCard = new Card();
    int suitCounts[] = {0,0,0,0};
    int cardCounts[] = {0,0,0,0,0,0,0,0,0,0,0,0,0};//13 zeroes
    
    //test the jfraame
    static JFrameCardGame theFrame;
    static DefaultListModel cards;
    static JLabel lblWin;
    static JButton btnNewDeal;
    static JButton btnHigh;
    static JButton btnLow;
    static Card lastCard, newCard;

    @BeforeClass
    public static void setupClass(){
        theFrame = new JFrameCardGame();
        btnNewDeal = theFrame.getBtnDeal();
        btnHigh = theFrame.getBtnHigh();
        lblWin = theFrame.getLblWin();
        lastCard = theFrame.getLastCard();
        newCard = theFrame.getNewCard();

    }
    
    //test btnHigh
    @Test
    public void testHigh(){
        btnHigh.doClick();
        lastCard = theFrame.getLastCard();
        newCard = theFrame.getNewCard();
        String expected;
        
        if(lastCard.getValue() < newCard.getValue()){
            expected = "Good";
        } else{
            expected = "Bad";
        }
        lblWin = theFrame.getLblWin();
        assertEquals("BtnHigh fails", expected, lblWin.getText().toString());

    }
    
    
    public CardTest() {
    }

    /**
     * Test of pickCard method, of class Card.
     */
    @Test
    public void testPickCard() {
    int correctCardCount[] = {4,4,4,4,4,4,4,4,4,4,4,4,4};
    for(int x = 1; x <= 52; x++){
        aCard.pickCard();
        cardCounts[aCard.getValue() - 1]++;//count each location of the array when picked
    }
    assertArrayEquals("Card count is incorrect", correctCardCount, cardCounts);
    }
    @Test
    public void testPickCardSuites() {
    int correctSuitCount[] = {13,13,13,13};
    for(int x = 1; x <= 52; x++){
        aCard.pickCard();
        if(aCard.getSuit().equals("Hearts")){
            //hearts is position 0 in array
            suitCounts[0]++;
        }
        if(aCard.getSuit().equals("Spades")){
            //Spades is position 1 in array
            suitCounts[1]++;
        }
        if(aCard.getSuit().equals("Diamonds")){
            //Diamonds is position 2 in array
            suitCounts[2]++;
        }
        if(aCard.getSuit().equals("Clubs")){
            //Clubs is position 3 in array
            suitCounts[3]++;
        }
    }
    assertArrayEquals("Suit count is incorrect", correctSuitCount, suitCounts);
    }

    /**
     * Test of showCard method, of class Card.
     */
    @Test
    public void testShowCard() {
    }

    /**
     * Test of getSuit method, of class Card.
     */
    @Test
    public void testGetSuit() {
    }

    /**
     * Test of setSuit method, of class Card.
     */
    @Test
    public void testSetSuit() {
    }

    /**
     * Test of getValue method, of class Card.
     */
    @Test
    public void testGetValue_0args() {
    }

    /**
     * Test of getValue method, of class Card.
     */
    @Test
    public void testGetValue_String() {
    }

    /**
     * Test of setValue method, of class Card.
     */
    @Test
    public void testSetValue() {
    }

    /**
     * Test of toString method, of class Card.
     */
    @Test
    public void testToString() {
    }

    /**
     * Test of hashCode method, of class Card.
     */
    @Test
    public void testHashCode() {
    }

    /**
     * Test of equals method, of class Card.
     */
    @Test
    public void testEquals() {
    }
    
}
