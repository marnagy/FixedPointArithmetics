Pôjde o generickú štruktúru(Fixed<T> where T: Q), ktorá si ukladá počet desatinných pozícií v statickej premennej, t.j. pre každú triedu Q bude jedna taká premenná a bude inicializovaná v statickom konštruktore.
Jednotlivé triedy QXX_XX sú potomkovia abstractnej triedy Q, ktorá obsahuje abstraktnú metódu, ktorá má vracať počet bitov ZA desatinnou čiarkou.
===========
Pôvodne som chcel mať statickú metódu pre každú triedu Q, ale asi po 5 minútach mi došlo, že zo statickej typovanosti, to je zlý postup.
===========
Testy sú priložené
===========
Čas na riešenie:
pred: 30 minút
implementáciou: 2 hodiny (hlavne kvôli násobeniu a deleniu)
