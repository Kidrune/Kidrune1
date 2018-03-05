package woordenapplicatie.gui;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */



import java.net.URL;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashSet;
import java.util.List;
import java.util.ResourceBundle;
import java.util.SortedSet;
import java.util.TreeSet;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.TextArea;
import woordenapplicatie.WoordenMethods;

/**
 * FXML Controller class
 *
 * @author frankcoenen
 */
public class WoordenController implements Initializable {
   List<String> AllText;
   SortedSet<String> AllSortedSet;
   HashSet<String> uniekewoorden;
   WoordenMethods woordenMethods;
   private static final String DEFAULT_TEXT =   "een, twee, drie, vier\n" +
                                                "hoedje van hoedje van\n" +
                                                "een, twee, drie, vier\n" +
                                                "hoedje van papier\n";
    
   
   private static final String DEFAULT_TEXT2 = "Een, twee, drie, vier\n" +
                                                "Hoedje van, hoedje van\n" +
                                                "Een, twee, drie, vier\n" +
                                                "Hoedje van papier\n" +
                                                "\n" +
                                                "Heb je dan geen hoedje meer\n" +
                                                "Maak er één van bordpapier\n" +
                                                "Eén, twee, drie, vier\n" +
                                                "Hoedje van papier\n" +
                                                "\n" +
                                                "Een, twee, drie, vier\n" +
                                                "Hoedje van, hoedje van\n" +
                                                "Een, twee, drie, vier\n" +
                                                "Hoedje van papier\n" +
                                                "\n" +
                                                "En als het hoedje dan niet past\n" +
                                                "Zetten we 't in de glazenkas\n" +
                                                "Een, twee, drie, vier\n" +
                                                "Hoedje van papier";
    @FXML
    private Button btAantal;
    @FXML
    private TextArea taInput;
    @FXML
    private Button btSorteer;
    @FXML
    private Button btFrequentie;
    @FXML
    private Button btConcordantie;
    @FXML
    private TextArea taOutput;

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        taInput.setText(DEFAULT_TEXT.toLowerCase());
        AllText = new ArrayList<>();
        woordenMethods = new WoordenMethods();
        woordenMethods.setwoorden(DEFAULT_TEXT);
        //setwoorden();
    }
    
    //Zetten van juiste woorden in een lijst
    public void setwoorden()
    {
        String[] woorden = taInput.getText().split(" |\n");
        
        for (int i = 0; i < woorden.length; i++) {
            if(!woorden[i].isEmpty())
            {
               AllText.add(woorden[i]); 
            }
        } 
    }
    
    @FXML
    private void aantalAction(ActionEvent event) {
            //uniekewoorden = new HashSet<>(AllText);
            
            //taOutput.setText(Integer.toString(AllText.size()) + " " + Integer.toString(uniekewoorden.size()));
            
            taOutput.setText(woordenMethods.calcaantal(DEFAULT_TEXT));
         //throw new UnsupportedOperationException("Not supported yet."); 
    }

    @FXML
    private void sorteerAction(ActionEvent event) {
        //Collections.reverse((List<?>) uniekewoorden);
        //AllSortedSet = new TreeSet<>(Collections.reverseOrder());
        //AllSortedSet.addAll(uniekewoorden);
        
        taOutput.setText(woordenMethods.calcsort(DEFAULT_TEXT));
        //throw new UnsupportedOperationException("Not supported yet."); 
    }

    @FXML
    private void frequentieAction(ActionEvent event) {
        taOutput.clear();
//        List<String> freqwoorden = new ArrayList<>();
//        for(String key : uniekewoorden)
//        {
//            freqwoorden.add(key + ": " + Collections.frequency(AllText, key));
//            taOutput.appendText(key + ": " + Collections.frequency(AllText, key) + " \n");
//        }
        taOutput.setText(woordenMethods.calcfreq(DEFAULT_TEXT));
//        freqwoorden.sort(Comparator.comparingInt(keyExtractor));
//        for (String string : freqwoorden) {
//            taOutput.appendText(string);
//        }
        
        
        //throw new UnsupportedOperationException("Not supported yet."); 
    }

    @FXML
    private void concordatieAction(ActionEvent event) {
        taOutput.clear();
        taOutput.setText(woordenMethods.calcconcordantie(DEFAULT_TEXT));
    }
   
}
