package com.andrascsanyi.functional_programming.supplier;

import java.util.function.Supplier;

public class NameImpl implements Name {
    
    private Supplier<String> firstNameSupplier;
    
    private Supplier<String> lastNameSupplier;
    
    @Override
    public void firstName(Supplier<String> firstNameSupplier) {
        
        this.firstNameSupplier = firstNameSupplier;
    }
    
    @Override
    public void lastName(Supplier<String> lastNameSupplier) {
        
        this.lastNameSupplier = lastNameSupplier;
    }
    
    @Override
    public void build() {
        
        String result = String.format("%s %s", firstNameSupplier.get(), lastNameSupplier.get());
        System.out.println(result);
    }
}
