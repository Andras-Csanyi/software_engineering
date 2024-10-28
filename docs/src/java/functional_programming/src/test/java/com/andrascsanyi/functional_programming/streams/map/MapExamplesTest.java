package com.andrascsanyi.functional_programming.streams.map;

import java.util.Arrays;
import java.util.List;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;

public class MapExamplesTest {

    @Test
    public void operationOnElementsOfList() {
        List<Integer> integers = Arrays.asList(1, 2, 3);
        List<Integer> result = integers.stream()
            .map(val -> val * 2)
            .toList();

        assertThat(result).contains(2, 4, 6);
        assertThat(result).doesNotContain(1, 3);
    }

    @Test
    public void chainedMaps() {
        List<Integer> integers = Arrays.asList(1, 2, 3);
        List<Integer> result = integers.stream()
            .map(val -> val * 2)
            .map(val -> val + 1)
            .toList();

        assertThat(result).contains(3, 5, 7);
        assertThat(result).doesNotContain(2, 4, 6);
    }

    @Test
    public void mapExternalFunction() {
        List<Integer> integers = Arrays.asList(1, 2, 3);
        List<Integer> result = integers.stream()
            .map(MapExamplesTest::externalFunction)
            .map(val -> val + 1)
            .toList();

        assertThat(result).contains(3, 5, 7);
        assertThat(result).doesNotContain(2, 4, 6);
    }

    public static Integer externalFunction(Integer input) {
        return input * 2;
    }
}