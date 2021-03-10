# task-eyos-evaluator

## instruction
Consider an expression with the following form:

- ELEM = 0 | 1 | 2 ... 9 | 10 | 11 ...
- ADD = ( EXPR + EXPR + ... + EXPR )
- MULT = ( EXPR * EXPR * ... * EXPR )
- EXPR = ELEM | ADD | MULT

So these are all valid expressions:

- 1
- (1+1)
- (1+2+1)
- (1+2+1)*(1+1)

Your task is to write a CLI program that, given an expression of the above form, outputs what the expression evaluates to.

For example:

- 1 -> 1
- (1+1) -> 2
- (1+2+1) -> 4
- ((1+2+1)*(1+1)) -> 8

To make things easier:

1. You can assume there is no whitespace in the input.
2. You can assume there are always brackets around sequences of + and * even when they wouldn't be required due to order of operations.
3. You can assume there are no negative numbers.


## instruction updated
Consider the following change to the take-home exercise, namely allowing a variable “x”:

ELEM = x | 0 | 1 | 2 ... 9 | 10 | 11 ...
ADD = ( EXPR + EXPR + ... + EXPR )
MULT = ( EXPR * EXPR * ... * EXPR )
EXPR = ELEM | ADD | MULT

For example:
1 -> 1
x -> x
(x+1) -> (x+1)
(1+(2*x)+1) -> ((2*x)+2)
((1+(2*x)+1)*(x+1)) -> ((2*x^2)+(4*x)+2)

Other than the addition of the variable “x” the task is the same as the original take-home exercise.

