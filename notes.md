# Benchmark Notes

-------------

## Different implementations

* long constructor's speed is comparable on multiplication and division
* long constructor is slower on addition and subtraction

## Comparing to Float and Double

* both are considerably slower than Fixed
* main reason being Fixed is internally operating on int while others use floating point

### Subnotes

* Matrix classes are used only for Gaussian elimination