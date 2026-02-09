package relation.dependancy;

import static org.junit.Assert.*;
import org.junit.Test;

public class SumTest {
    @Test
    public void shouldProduceSumOfGivenNumbers() {
        Sum sum = new Sum();
        assertEquals(5, sum.sum(2, 3));
    }
}