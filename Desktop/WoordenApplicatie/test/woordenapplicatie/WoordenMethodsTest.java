/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package woordenapplicatie;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Jeffrey
 */
public class WoordenMethodsTest {
    
    private static final String text =   "een, twee, drie, vier\n" +
                                                "hoedje van hoedje van\n" +
                                                "een, twee, drie, vier\n" +
                                                "hoedje van papier\n";
    WoordenMethods woordenMethods;
    public WoordenMethodsTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
        woordenMethods = new WoordenMethods();
        woordenMethods.setwoorden(text);
    }
    
    @After
    public void tearDown() {
    }

    /**
     * Test of setwoorden method, of class WoordenMethods.
     */
    @Test
    public void testSetwoorden() {
        System.out.println("setwoorden");
        //String text = "";
        //WoordenMethods instance = new WoordenMethods();
        woordenMethods.setwoorden(text);
        // TODO review the generated test code and remove the default call to fail.
        //fail("The test case is a prototype.");
    }

    /**
     * Test of calcaantal method, of class WoordenMethods.
     */
    @Test
    public void testCalcaantal() {
        System.out.println("calcaantal");
        //String text = "";
        String expResult = "15 7";
        String result = woordenMethods.calcaantal(text);
        System.out.println(result);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        //fail("The test case is a prototype.");
    }

    /**
     * Test of calcsort method, of class WoordenMethods.
     */
    @Test
    public void testCalcsort() {
        System.out.println("calcsort");
        //String text = "";
        woordenMethods.calcaantal(text);
        String expResult = "[vier, van, twee,, papier, hoedje, een,, drie,]";
        String result = woordenMethods.calcsort(text);
        System.out.println(result);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        //fail("The test case is a prototype.");
    }

    /**
     * Test of calcfreq method, of class WoordenMethods.
     */
    @Test
    public void testCalcfreq() {
        System.out.println("calcfreq");
        //String text = "";
        String expResult = "[1 : papier, 2 : drie,, 2 : een,, 2 : twee,, 2 : vier, 3 : hoedje, 3 : van]";
        String result = woordenMethods.calcfreq(text);
        System.out.println(result);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        //fail("The test case is a prototype.");
    }

    /**
     * Test of calcconcordantie method, of class WoordenMethods.
     */
    @Test
    public void testCalcconcordantie() {
        System.out.println("calcconcordantie");
        //String text = "";
        String expResult = "{een,=[1, 3], hoedje=[2, 4], van=[2, 4], twee,=[1, 3], drie,=[1, 3], vier=[1, 3], papier=[4]}";
        String result = woordenMethods.calcconcordantie(text);
        System.out.println(result);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        //fail("The test case is a prototype.");
    }
    
}
