package com.andrascsanyi.functional_programming.streams.flatmap;

import java.util.Arrays;
import java.util.Collection;
import java.util.List;
import org.junit.jupiter.api.Test;

import static java.util.stream.Collectors.toList;
import static org.assertj.core.api.Assertions.assertThat;

public class FlatMapExamplesTest {

    @Test
    public void flatMap() {
        List<List<String>> listOfLists = Arrays.asList(
            Arrays.asList("first list first elem", "first list second elem"),
            Arrays.asList("second list first elem", "second list second elem")
        );

        List<String> result = listOfLists.stream()
            .flatMap(List::stream)
            .toList();

        assertThat(result).isInstanceOf(List.class);
        System.out.println(result);
    }

    @Test
    public void flatteningNestedArrays() {
        String[][] arrays = new String[][]{
            {"1-1", "1-2"},
            {"2-1", "2-2"},
            {"3-1", "3-2"}
        };

        List<String> result = Arrays.stream(arrays)
            .flatMap(Arrays::stream)
            .toList();

        assertThat(result).isInstanceOf(List.class);
        System.out.println(result);
    }

    @Test
    public void flatteningNumericArraysAndSum(){
        List<List<Integer>> numbers = Arrays.asList(
            Arrays.asList(1,11, 111),
            Arrays.asList(2,22, 222),
            Arrays.asList(3,33, 333)
        );

        Integer result = numbers.stream()
            .flatMap(Collection::stream)
            .mapToInt(Integer::intValue)
            .sum();

        System.out.println(result);
    }

}