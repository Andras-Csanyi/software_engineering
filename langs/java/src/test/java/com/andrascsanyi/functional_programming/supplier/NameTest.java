package com.andrascsanyi.functional_programming.supplier;

import com.andrascsanyi.functional_programming.supplier.Name;
import com.andrascsanyi.functional_programming.supplier.NameImpl;
import org.junit.jupiter.api.Test;

public class NameTest {
    
    @Test
    public void nameTest() {
        
        Name name = new NameImpl();
        name.firstName(() -> {
            // you can do a few things here
            return "Andras";
        });
        name.lastName(() -> {
            // you can do a few things here
            return "Csanyi";
        });
        name.build();
        
    }
}
