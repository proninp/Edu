package org.Stepik.JavaBasicCourse;

public final class ComplexNumber {
    private final double re;
    private final double im;

    public ComplexNumber(double re, double im) {
        this.re = re;
        this.im = im;
    }

    public double getRe() {
        return re;
    }

    public double getIm() {
        return im;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == this)
            return true;
        if (!(obj instanceof ComplexNumber complexNumber))
            return false;
        return complexNumber.im == this.im && complexNumber.re == this.re;
    }
    @Override
    public int hashCode() {
        int result = 1;
        result *= 31 + Double.hashCode(this.im);
        result *= 31 + Double.hashCode(this.re);
        return result;
    }

}
