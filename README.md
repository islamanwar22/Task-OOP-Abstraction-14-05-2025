When should I use a struct instead of a class?


يعني ممكن نقول اذا ممكن نستغني عن مبادئ البرمجة الشيئية يمكننا استخدام الstruct بدلا من الclass

Use a struct if:

You need a lightweight object.

You don’t need inheritance or shared state.

You want safer immutability and no side effects.

Use a class if:

You need polymorphism or inheritance.

You need shared state or large data.

You want to model complex behaviors or entities.
