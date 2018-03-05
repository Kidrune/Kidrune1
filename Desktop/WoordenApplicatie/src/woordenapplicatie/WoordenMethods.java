/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package woordenapplicatie;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.SortedSet;
import java.util.TreeSet;

/**
 *
 * @author Jeffrey
 */
public class WoordenMethods {
    
    List<String> AllText;
    SortedSet<String> AllSortedSet;
    HashSet<String> uniekewoorden;
    
    public WoordenMethods()
    {
        AllText = new ArrayList<>();
    }
    
    public void setwoorden(String text)
    {
        String[] woorden = text.split(" |\n");
        
        for (String woorden1 : woorden) {
            if (!woorden1.isEmpty()) {
                AllText.add(woorden1); 
            }
        } 
    }
    
    
    public String calcaantal(String text)
    {
        uniekewoorden = new HashSet<>(AllText);
        
        return AllText.size() + " " + uniekewoorden.size();
    }
    
    
    public String calcsort(String text)
    {
        AllSortedSet = new TreeSet<>(Collections.reverseOrder());
        AllSortedSet.addAll(uniekewoorden);
        
        return AllSortedSet.toString();
    }
    
    
    
    
    public HashMap<Integer, List<String>> wordCount() {
        HashMap<String, Integer> map = new HashMap<> ();
        AllText.forEach((s) -> {
            if (!map.containsKey(s)) {
                map.put(s, 1);
            }
            else {
                int count = map.get(s);
                map.put(s, count + 1);
            }
        });

        HashMap<Integer, List<String>> reverseMap = new HashMap<>();

        map.entrySet().forEach((Map.Entry<String, Integer> entry) -> {
            if (!reverseMap.containsKey(entry.getValue())) {
                List<String> stringList = new ArrayList<>();
                stringList.add(entry.getKey());
                reverseMap.put(entry.getValue(), stringList);
            }
            else {
                int count = entry.getValue();
                reverseMap.get(count).add(entry.getKey());
            }
        });

        return reverseMap;
    }
    
    public String calcfreq(String text)
    {
        List<String> al = new ArrayList<>();
        //String[] s = (String[]) AllText.toArray();
        HashMap<Integer, List<String>> map = wordCount();

        map.entrySet().forEach((Map.Entry<Integer, List<String>> entry) -> {
            entry.getValue().stream().map((string) -> {
                System.out.println(string + ": " + entry.getKey());
                return string;
            }).forEachOrdered((string) -> {
                al.add(string + ": " + entry.getKey());
            });
        }); //taInput.setText(wordCount(s).toString());
        
        return al.toString();
        //taInput.setText(wordCount(s).toString());
        


//        Map<Integer, List<String>> mappie = new HashMap<>();
//        for (String w : AllText) {
//            Integer n = mappie.get(w);
//            n = n == null ? 1 : ++n;
//            mappie.put(w, n);
//        }  
        
        
//        Object[] a = mappie.entrySet().toArray();
//        Arrays.sort(a, new Comparator() {
//            public int compare(Object o1, Object o2) {
//                return ((Map.Entry<String, Integer>) o1).getValue()
//                           .compareTo(((Map.Entry<String, Integer>) o2).getValue());
//            }
//        });
//
//        List<String> al = new ArrayList<String>();
//
//        for (Object e : a) {
//            System.out.println(((Map.Entry<String, Integer>) e).getKey() + " : "
//                    + ((Map.Entry<String, Integer>) e).getValue());
//            al.add(((Map.Entry<String, Integer>) e).getKey() + " : " + ((Map.Entry<String, Integer>) e).getValue());
//        }
      
            
//        LinkedHashMap<String, Integer> sortedHashMapByKeys = new LinkedHashMap<>(); //maintains the order of putting
//        TreeMap<String, Integer> originalTreeMap = new TreeMap<>(mappie); //sorts based on keys
//        for (Map.Entry<String, Integer> map: originalTreeMap.entrySet()) {
//            sortedHashMapByKeys.put(map.getKey(), map.getValue());
//        }
//
//        LinkedHashMap<Integer, String> reversedOfSortedLinkedHashMap = new LinkedHashMap<>();
//        for (Map.Entry<String, Integer> map: sortedHashMapByKeys.entrySet()) {
//            reversedOfSortedLinkedHashMap.put(map.getValue(), map.getKey());
//        }
//
//        LinkedHashMap<String, Integer> finalMap = new LinkedHashMap<>();
//        TreeMap<String, Integer> treeMapOfReversedOfSortedLinkedHashMap = new TreeMap<>(reversedOfSortedLinkedHashMap);
//        for (Map.Entry<String, Integer> map: treeMapOfReversedOfSortedLinkedHashMap.entrySet()) {
//            finalMap.put(map.getKey(), map.getValue()); //sort and swap
//        }


            
  
//        
//        for(Map.Entry<String, Integer> mapData : map.entrySet()) {
//    System.out.println("Key : " +mapData.getKey()+ "Value : "+mapData.getValue());
//    }
//        
        //SortedSet<String> keys = new TreeSet<String>(map.keySet());    
        //List<String> al = new ArrayList<String>();
//        for (Map.Entry<String, Integer> entry : mappie.entrySet()) {
//            
//            al.add(entry.getValue() + " : " + entry.getKey());
//        }
        
        
//        Collections.sort(al);
//        
//        result = al.toString();
//        return al.toString();
        
        
    }
    
    public String calcconcordantie(String text)
    {
        String[] lines = text.split("\\\n");

        Map<String, List<Integer>> map = new HashMap<>();
        AllText.forEach((w) -> {
            map.put(w, new ArrayList<>());
        });

        map.keySet().forEach((key) -> {
            List<Integer> list = new ArrayList<>();
            int linenumber = 1;
            for (String line : lines) {
                if(line.contains(key))
                    list.add(linenumber);

                linenumber++;
            }
            map.put(key, list);
        });
        
        return map.toString();
    }
}
