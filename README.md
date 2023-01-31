# Cartesian Product
Realizes cartesian product of multiple enumenrables.
{A, B, C}, {E, F, G}, {H, I, J} => {A, E, H}, {A, E, I}, {A, E, J}, {A, F, H} ... {C, G, J}
Seems working, but not realy well tested.

Initial code taken from here https://codereview.stackexchange.com/a/140428 and modified as to be genericly-typed and also to account that (some) collections in core library do not implement Enumerator Reset, so I had to create ResetableEnumerator decorator. More on that https://stackoverflow.com/questions/1468170/why-the-reset-method-on-enumerator-class-must-throw-a-notsupportedexception
