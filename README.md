# Cartesian Product
Realizes cartesian product of multiple enumenrables.
{A, B, C}, {E, F, G}, {H, I, J} => {A, E, H}, {A, E, I}, {A, E, J}, {A, F, H} ... {C, G, J}
Seems working, but not realy well tested.

Initial code taken from here https://codereview.stackexchange.com/a/140428 and modified to work as Enumerable yield thingy and also to account that some collections, even in core library, do not implement Enumerator Reset, so I had to create ResetableEnumerator decorator.
