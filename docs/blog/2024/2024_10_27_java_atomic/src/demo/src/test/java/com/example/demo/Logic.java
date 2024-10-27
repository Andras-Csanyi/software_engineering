package com.example.demo;

import java.util.List;
import java.util.concurrent.atomic.AtomicInteger;

public class Logic {

    // snippet demonstration start
    public void logicDemonstration(List<SomeDataClass> input){
        Integer value = 0;

        input.forEach(data -> {
            value += data.getSomeNumber();
        });

        System.out.println(value);
    }
    // snippet demonstration end

    // snippet atomic start
    public void logicAtomicInteger(List<SomeDataClass> input){
        AtomicInteger value = new AtomicInteger(0);

        input.forEach(data -> {
            value.updateAndGet(v -> v + data.getSomeNumber());
        });

        System.out.println(value);
    }
    // snippet atomic end

    // snippet solution
    public void logicWithoutAtomic(List<SomeDataClass> input){
        Integer value = 0;

        Integer sum = input.stream().filter(data -> data.getSomeNumber() > 0)
            .mapToInt(SomeDataClass::getSomeNumber)
            .sum();

        System.out.println(value + sum);
    }
    // snippet solution end
}