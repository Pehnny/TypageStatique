# [Introduction](/README.md#introduction)

1) **Déclaration et mutation de variable en JavaScript**
```js
//  JavaScript
let variable = 1;
variable = "text";
```
2) **Déclaration de variable en C#**

*Invalide*
```cs
//  C#
int variable = 1;
variable = "text";
//  error CS0029: Impossible de convertir implicitement le type 'string' en 'int'
```

*Valide*
```cs
//  C#
int variable1 = 1;
string variable2 = "text";
```

3) **Déclaration de variable en Rust**

*Sans inférence de type*
```rust
//  Rust
let variable : i32 = 1;
```

*Avec inférence de type*
```rust
//  Rust
let variable = 1;
```

# [Typage statique](/README.md#typage-statique)

## [Fonctions et classes](/README.md#fonctions-et-classes)

1) **Déclaration d'une fonction `somme()`**
    - [javascript/somme](/javascript/somme.mjs)
    - [rust/somme](/rust/techtalk/src/somme/mod.rs)

2) **Utilisation des fonction `somme()`**
    - [javascript/main](/javascript/main.mjs)
    - [rust/main](/rust/techtalk/src/main.rs)

3) **Déclaration d'une classe Exemple**
    - [dotnet/Exemple](/dotnet/techtalk/TechTalk/Exemple.cs)

4) **Avantages**
    - Immutabilité (prévient des erreurs)
    - IntelliSense (autocomplétion)

5) **Questions**
    - **Que devons-nous faire si nous voulons que notre fonction `somme()` accepte des nombres décimaux ou des chaines de caractères en paramètre  comme en JavaScript ?**
    - **Devons-vous écrire une autre version de cette fonction pour chaque type existant ?**
    
## [Héritage et polymorphisme](/README.md#héritage-et-polymorphisme)

1) **Héritage**
    - [dotnet/Heritage](/dotnet/techtalk/TechTalk/Heritage.cs)

2) **Polymorphisme**
    - [dotnet/Polymorphisme](/dotnet/techtalk/TechTalk/Polymorphisme.cs)
        - Classe
        - Classe abstraite
    - [dotnet/Composition](/dotnet/techtalk/TechTalk/Composition.cs)
        - Interface
    - [dotnet/Program](/dotnet/techtalk/TechTalk/Program.cs)

3) **Inconvénient**
    - Mutabilité

4) **Question**
    - **Comment reproduire la flexibilité du typage dynamique sans perdre l'immutabilité ?**

## [Programmation générique](/README.md#programmation-générique)

1) **Déclaration de la méthode générique `Somme<T>()`**
    - [dotnet/Somme](/dotnet/techtalk/TechTalk/Somme.cs)
    - [dotnet/Program](/dotnet/techtalk/TechTalk/Program.cs)

2) **Déclaration du classe générique `Cage<T>`**
    - [dotnet/Generique](/dotnet/techtalk/TechTalk/Generique.cs)
    - [dotnet/Program](/dotnet/techtalk/TechTalk/Program.cs)
        - Mélange des deux approches

3) **Exemple complexe**

```cs
//  C#
class Exemple
{
    public static void ExempleMethode<T, U, V>(T arg1, U arg2, V arg3, int arg4, string arg5) 
    where T : ICrier, IVoler
    where U : Cage<T>
    {
        // code
    }
}
```

# Conclusion

1) [Redmonk](https://redmonk.com/sogrady/2024/09/12/language-rankings-6-24/)

2) [TIOBE](https://www.tiobe.com/tiobe-index/)

3) [TypeScript](https://www.typescriptlang.org/)