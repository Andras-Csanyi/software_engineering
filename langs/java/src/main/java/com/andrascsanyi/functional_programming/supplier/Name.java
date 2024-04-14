package com.andrascsanyi.functional_programming.supplier;

import java.util.function.Supplier;

public interface Name {
    
    void firstName(Supplier<String> firstNameSupplier);
    
    void lastName(Supplier<String> lastNameSupplier);
    
    void build();
}
