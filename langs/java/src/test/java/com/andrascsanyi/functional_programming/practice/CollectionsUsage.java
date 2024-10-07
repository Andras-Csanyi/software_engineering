package com.andrascsanyi.functional_programming.practice;

import java.util.List;

import org.junit.jupiter.api.Test;

public class CollectionsUsage {

    private final List data = List.of("Brian", "Francis", "George", "Henrik", "Jack");


    @Test
    public void usingForeach(){
        data.forEach(i -> {System.out.println(i);});
    }
}
