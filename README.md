# Langages de programmation au typage statique

Le présent repo s'addresse aux développeurs juniors qui n'ont connu que des langages dont le système de typage est dynamique comme **JavaScript** ou **Python**. L'objectif est de vous introduire aux langages dont le système de typage est *a contrario* statique. Nous illustrerons tous les concepts que nous aborderons avec 3 langages de programmation : **JavaScript**, **C#** et **Rust**. 

- [Introduction](#introduction)
- [Typage statique](#typage-statique)
    - [Fonctions et classes](#fonctions-et-classes)
    - [Heritage et polymorphisme](#héritage-et-polymorphisme)
        - [Rappels](#rappels)
        - [Typage statique et polymorphisme](#typage-statique-et-polymorphisme)
    - [Programmation générique](#programmation-générique)
- [Conclusion](#conclusion)

## Introduction

Commençons par une évidence : Dans un système de typage dynamique, une variable peut changer de type à n'importe quel moment. Par exemple, nous pouvons assigner un nombre à une variable, puis changer sa valeur avec une chaine de caractère :

```js
//  JavaScript
let variable = 1;
variable = "text";
```

En revanche, si nous faisons la même chose dans un système de typage statique, nous rencontrons une erreur :

```cs
//  C#
int variable = 1;
variable = "text";
//  error CS0029: Impossible de convertir implicitement le type 'string' en 'int'
```

Profitons de la simplicité de cet exemple pour remarquer que, dans un système de typage statique, nous devons déclarer le type que nous voulons associer à une variable. En l'occurence, `variable` est de type `int`, un nombre entier. Afin d'assigner la chaine de caractère `"text"` à une variable, nous sommes obligé d'en déclarer une autre :

```cs
//  C#
int variable1 = 1;
string variable2 = "text";
```

La syntaxe `type <name>` pour déclarer une variable est considérée désuète aujourd'hui. Nous la trouverons généralement dans des langages qui ont au moins 20 ans comme **C++**, **C#** ou **Java**. Les langages modernes comme **Kotlin** et **Rust** utilisent une syntaxe de la forme `keyword <name> : type` :

```rust
//  Rust
let variable : i32 = 1;
```

Cette syntaxe se rapproche de celle des langages à typage dynamique comme **JavaScript**. Avec le temps, les système de typage statique ont acquis la capacité d'inférer le type d'une variable en fonction de la valeur que nous lui assignons. Nous pouvons donc simplifier le code précédent :

```rust
//  Rust
let variable = 1;
```

Il ne reste plus aucune différence avec la syntaxe de `JavaScript`. Cependant, il existe des situations où le contexte ne permet pas au système d'inférer le type d'une variable. Dans ce cas, c'est notre responsabilité de le préciser.

Pour conclure cette introduction, notons que les langages plus anciens comme **C#** et **Java** sont également capable d'inférer un type. Afin d'imiter la syntaxe moderne, ces deux langages utilisent le mot clef `var`. Malheureusement, quand le système ne peut pas inférer le type d'une variable, nous devons utiliser la vieille syntaxe. Penchons nous maintenant sur les spécificités des systèmes de typage statique afin d'en tirer les avantages et les inconvénients.

## Typage statique

Dans l'[introduction](#introduction), nous avons vu comment un système de typage statique impact la déclaration et l'assignation de variables. Toutefois, un exemple aussi basique ne nous permet pas de rendre nous compte de toutes les implications de ces systèmes. Regardons comment déclarer des fonctions et des classes afin d'explorer les spécificités du typage statique plus en profondeur. 

### Fonctions et classes
---

Commençons par regarder comment construire une fonction qui additionne 2 nombres entiers en **JavaScript** et en **Rust**.

- [javascript/somme](/javascript/somme.mjs)
- [rust/somme](/rust/techtalk/src/somme/mod.rs)

Dans l'exemple écrit en **Rust**, le type des paramètres `a` et `b`, ainsi que le type de retour de la fonction `somme()`, sont précisés. Contrairement aux variables, ces précisions sont obligatoires car le système ne peut pas inférer le type de ces paramètres avant que nous appelons la fonction et nous n'appelons pas une fonction lorsque nous la déclarons (exception faite des fonctions anonymes que nous n'aborderons pas). De plus, chaque paramètre d'entrée et de sortie de la fonction `somme()` sont de même type (`i32`), c'est évidemment fortuit.

Une fois que nous avons attribué un type à chaque paramètre de la fonction (y compris le retour), nous somme contraint de respecter ce typage lorsque nous l'[appelons](/rust/techtalk/src/main.rs). Ce n'est pas vrai dans un système de typage dynamique. Par exemple, bien que la fonction `somme()` écrite en **JavaScript** soit prévue pour additionner des nombres, rien ne nous empêche de l'[utiliser](/javascript/main.mjs) pour concaténer deux chaines de caractères :

```js
//  JS
somme("une chaine", "de caractères")
```

En revanche, si nous essayons d'appeler la fonction `somme()` écrite en **Rust** sur ces deux mêmes chaines de caractères, nous obtenons l'erreur suivante :

```sh
error[E0308]: arguments to this function are incorrect
```

Tout ce que nous venons de dire est également vrai pour une classe, ses attributs et ses méthodes. Pour illustrer, définissons une classe simple, en **C#**, qui possède deux attributs, `nom` et `valide` :

- [dotnet/Exemple](/dotnet/techtalk/TechTalk/Exemple.cs)

Lorsque nous déclarons une classe, nous devons préciser le type de chacun de ses attributs. En conséquence, nous devons respecter le type de ces attributs lorsque nous instancions la classe `Exemple`. Le code suivant génère une erreur :

```cs
//  C#
var exemple = new Exemple(0, false);
//  Argument 1: cannot convert from 'int' to 'string'
```

Parlons à présent des avantages et des inconvénients des système de typage statique. Tout d'abord, comparé à un système de typage dynamique, le typage statique est contraignant comme nous l'avons vu avec la fonction `somme()`. En contrepartie, cette contrainte prévient un ensemble d'erreurs qui, en **JavaScript**, se manifestent par l'apparition de valeurs `undefined` un peu partout. A titre d'exemple, cette erreur se produit quand nous essayons d'utiliser la méthode `map()` sur une variable de type `String`. Les systèmes de typage statique préviennent ce genre d'erreur. Toutefois, ces systèmes ne sont pas infaillibles. Ils ne peuvent pas prévenir une erreur de type si une valeur n'est connue qu'au moment de l'exécution, comme lorsqu'un client communique avec un serveur.

Un autre avantage des systèmes de typage statique prend place dans les IDE. Puisque que le système peut connaitre le type de chaque variable ou les types attendus dans une fonction à chaque instant, notre IDE le peut aussi. En conséquence, les IDE utilisent ces informations pour proposer de l'autocomplétion de code et de la détection d'erreur. L'outil qui permet de faire ça s'appelle **IntelliSense**.

Revenons une dernière fois sur la contrainte de notre fonction `somme()` écrite en **Rust** avec un questionnement légitime : **Que devons-nous faire si nous voulons que notre fonction `somme()` accepte des nombres décimaux ou des chaines de caractères en paramètre  comme en JavaScript ? Devons-vous écrire une autre version de cette fonction pour chaque type existant ?** A une époque pas si lointaine, c'est effectivement ce que nous aurions dû faire. Heureusement, des outils permettent de reproduire la flexibilité du typage dynamique au sein des systèmes de typage statique mais avec plus de contrôle : l'**héritage**, **polymorphisme** et la **programmation générique**. Chacun de ces concepts à des applications différentes et complémentaires qui ne se cantonnent pas au typage.

Nous illustrerons toutes ces approches en **C#** car ce langage incorpore aussi bien les vieux outils qui permettent de mettre en place ces stratégies que les nouveaux.

### Héritage et polymorphisme
---

L'héritage et le polymorphisme sont des concepts intimement liés, nous les traitons donc simultanément. Si vous êtes familier de la programmation orienté objet, vous connaissez déjà ces deux concepts, mais un rappel ne fera de mal à personne.

#### Rappels
---

L'**héritage** est le mécanisme par lequel une classe `B` copie les attributs, les méthodes et les implémentations des méthodes d'une autre classe `A`. Dit de manière plus concise, **une classe hérite d'une autre quand elle reçoit son implémentation** et uniquement son implémentation. L'héritage ne doit pas être confondu avec le fait de copier les valeurs d'une instance vers une autre. Une classe héritière `B` peut avoir des attributs et des méthodes que la classe parent `A` ne possède pas. La réciproque n'est pas vraie.

- [dotnet/Heritage](/dotnet/techtalk/TechTalk/Heritage.cs)

De son côté, le **polymorphisme** est le mécanisme par lequel deux classes `B` et `C` partagent une ou plusieurs méthodes (uniquement des méthodes) mais ces méthodes ont des implémentations différentes. La manière le plus simple de procéder à un polymorphisme est d'utiliser une troisième classe `A` pour stocker les méthodes communes, de faire hériter l'implémentation de cette classe `A` aux deux autres classes `B` et `C` et de modifier les implémentations des méthodes. Une approche plus moderne, toujours fondée sur l'héritage, consiste à utiliser des **classes abstraites** qui sont des classes qui vérifient deux propriétés :

1) Une classe abstraite ne peut pas être instanciée.
2) Les méthodes d'une classe abstraite ne nécessitent pas d'implémentation.

Regardons un exemple sans plus attendre.

- [dotnet/Polymorphisme](/dotnet/techtalk/TechTalk/Polymorphisme.cs)

En l'absence de classe abstraite dans les outils d'un langage, si une classe parent `A` n'a pas vocation à être instanciée, la convention est que l'implémentation de toutes ses méthodes doivent générer une erreur.

Pour conclure ce rappel, regardons comment faire du polymorphisme sans héritage. Sans héritage, la seule façon de faire est la composition de classes. Pour mettre en place cette stratégie, nous n'avons besoin que de 2 classes `B` et `C` qui partagent au moins une méthode. Ces méthodes communes ont des implémentations différentes bien entendu. Pour des raisons technique, le polymorphisme par composition de classes utilise également une classe intermédiaire `A` pour stocker les méthodes communes. En effet, utiliser cette classe intermédiaire `A` permet au système de vérifier plus facilement si deux classes `B` et `C` partagent un ensemble de méthodes. 

*Les paradigmes d'héritage et de composition sont bien plus globaux que les applications au polymorphisme que nous en faisons. Le sujet "héritage contre composition" est un débat très prolifique en programmation orienté objet. Les portraits que nous en dressons ici sont réducteurs.*

En pratique, la composition diffère de l'héritage par sa plus grande modularité. En effet, plutôt que de réfléchir à une hiérarchie de classes qui va d'une entité globale vers des entités spécialisées semblables comme dans [les exemples](/dotnet/techtalk/TechTalk/Polymorphisme.cs) donnés précédemment, la composition consiste à définir des comportements qui seront attribués à des entités concrètes. Pour mettre en place un polymorphisme de composition, il existe un outil appelé **interface**. Les interfaces ressemblent aux classes abstraites et vérifient 3 propriétés :

1) Une interface ne peut pas être instanciée.
2) Les méthodes d'une interface ne peuvent pas avoir d'implémentation.</br>*En pratique, certains langages permettent aux interfaces d'avoir des implémentations par défaut pour des applications qui sortent du cadre du polymorphisme. C'est le cas en **C#**.*
3) Une interface ne peut pas avoir d'attributs.</br>*Là aussi, ce n'est pas toujours vrai. **C#** permet de déclarer des attributs de manière indirecte en déclarant des propriétés (getter & setter).*

*En **C#**, les interfaces et les classes abstraites sont interchangeables sauf sur un point : Une classe `B` ne peut **hériter** que d'une seule classe `A`, y compris si c'est une classe abstraite. En revanche, cette même classe `B` peut **implémenter** plusieurs interfaces.*

- [dotnet/Composition](/dotnet/techtalk/TechTalk/Composition.cs)

Dans ce dernier exemple, nous avons volontairement mélangé les deux approches car l'héritage et la composition ne sont pas mutuellement excluantes.

#### Typage statique et polymorphisme
---

Si vous connaissiez tous les concepts que nous venons de passer en revue, vous savez qu'ils ne sont absolument pas exclusifs aux langages à système de typage statique. Toutefois, nous avons fait ces rappels pour répondre à un objectif que nous nous sommes fixé : **Reproduire la flexibilité du typage dynamique au sein des systèmes de typage statique.**

Pour accomplir cet objectif, il nous suffit de prendre conscience de deux choses :

1) A chaque fois que nous déclarons une classe/interface, nous définissons également un **type personnalisé**.
2) Lorsqu'une classe `B` hérite d'une classe `A` ou implémente une interface `I`, elle reçoit également le type de la classe/l'interface. *Les types s'accumulent, la classe `B` conserve donc son type.*

En exploitant ces propriétés, nous pouvons manipuler un ensemble d'objets de types différents en utilisant le type d'une classe parent ou d'une interface commune.

- [dotnet/Program](/dotnet/techtalk/TechTalk/Program.cs)

Avec cette première approche, si nous construisons un ensemble de classes et d'interfaces dont les relations sont un minimum pertinentes, nous pouvons déjà passer outre les limitations du système de typage statique. Cependant, nous avons abordé l'existence d'une autre approche : **la programmation générique**.

### Programmation générique
---

La programmation générique, parfois aussi appelée polymorphisme de type, est une autre approche utilisée pour reproduire la flexibilité des système de typage dynamique. Son existence répond à un problème qui est une conséquence directe du polymorphisme par héritage :

- Bien que le polymorphisme par héritage permet de reproduire la flexibilité du typage dynamique, il reproduit également les comportements source d'erreurs : **la mutabilité de type**.

En effet, une conséquence du polymorphisme par héritage est que des classes héritières `B` et `C` d'une même classe `A` sont interchangeables. Nous avons écrit un [exemple](/dotnet/techtalk/TechTalk/Program.cs) avec une variable de type `Animal` à laquelle nous assignons un `Canard` avant de changer la valeur par un `Chat`. Bien que cet exemple ne pose pas de problème, la mutabilité de type peut générer des erreurs quand deux classe qui ont un ancêtre commun ont des méthodes qui leurs sont propres. Par exemple, un `Canard` pourrait a la capacité de voler mais un `Chat` pas. Si nous mélangeons des canards et des chats comme nous l'avons fait et que nous appelons la méthode `Voler()` sur tous les animaux de la liste, nous rencontrerons une erreur.

C'est cette problématique à laquelle répond la programmation générique. Elle permet la flexibilité que nous cherchons à produire, c'est-à-dire utiliser un `Canard` et un `Chat` avec une même fonction ou méthode tout en assurant l'**immutabilité de type**. Plongeons nous directement dans un exemple en reprenant la fonction `somme()` de l'[introduction](#introduction) que nous adapterons en une méthode statique puisque les fonctions n'existent pas en **C#** :

- [dotnet/Somme](/dotnet/techtalk/TechTalk/Somme.cs)

Dans cet exemple, nous définissons un **type générique** `T`. Nous pouvons interpréter ce générique comme une "variable de type" dont le nom est "T" et que nous passons à la méthode `Somme<T>()`. Cette méthode est appelée méthode générique (même chose pour une classe ou une fonction) de paramètre générique `T`. Ce paramètre générique `T` peut être utilisé de manière analogue aux paramètres de valeur `a` et `b` dans le contexte de la méthode.

*Un type générique peut avoir n'importe quel nom, comme une variable. A la place de `T`, nous aurions pu mettre `cupOfTea` sans que cela pose problème. Par contre, il existe des conventions de nommage. Par exemple, la lettre `N` est recommandée pour les types numériques. La lettre `T`, pour "type", est le choix par défaut.*

Attardons nous sur la déclation de notre méthode générique et regardons de plus près le rôle de chaque `T` : 

```cs
//  C#
public static T Somme<T>(T a, T b) where T : INumber<T>
              1       2  3    4          5           6
```

De toutes les apparitions de `T`, la plus importante est la numéro 2. La syntaxe `<T>` signifie que nous déclarons le type générique `T` comme paramètre de la méthode `T Somme<T>(a, b)`, de manière analogue que nous déclarons les paramètres `a` et `b` avec la syntaxe `(a, b)`. Les `T` numéros 1, 3 et 4 prennent simplement la place d'un type concret dans la déclaration d'une méthode. *L'écriture complète `T Somme<T>(a, b)` est la signature de la méthode. La signature d'une méthode (fonction) contient toujours son type de retour, son nom et ses paramètres (de type et de valeur). Toutefois, il est coutume d'abréger cette écriture en ne tenant compte que des paramètres de type.*

Avant de nous attarder sur les deux dernières occurences de `T`, regardons déjà de comment utiliser cette méthode générique. Lorsque nous appelons la méthode `Somme<T>()`, nous devons passer un type en entrée, en plus des valeurs habituelles :

```cs
//  C#
int sommeEntier = Arithmetique.Somme<int>(2, 3);
double sommeReel = Arithmetique.Somme<double>(0.2, 0.3);
```

Cette approche est différente du polymorphisme par héritage parce que même si `T` peut prendre n'importe quel type concret, une fois que nous lui avons assigné un type il ne peut plus en changer durant l'appel en cours. Dans cet exemple, nous appelons d'abord `Somme<T>()` avec le paramètre `int`. Une fois que nous avons appelé `Somme<int>()`,  il ne nous est plus possible de traiter `T` autrement que comme un nombre entier jusqu'à l'appel suivant. Nous ne pouvons donc pas passer un nombre décimal comme à la ligne suivante. La différencre fondamentale entre le polymorphisme de type et le polymorphisme par héritage sur cette immutabilité.

Illustrons cette propriété avec un autre exemple. Admettons que pour des raisons techniques, nous devons convertir tous les types numériques qui entrent dans la méthode `Somme<T>()` en type `double`. Nous ne pouvons pas le faire directement sur les paramètres de la fonction :

```cs
public static T Somme<T>(T a, T b) where T : INumber<T>
{
    a = Convert.ToDouble(a);
    return a + b;
}
// error CS0029: Impossible de convertir implicitement le type 'double' en 'T'
```

C'est la même erreur que nous avons rencontré dans l'[introduction](#introduction). Pour accomplir cette conversion, nous devons déclarer des nouvelles variables et ajuster la signature de la fonction :

```cs
//  C#
public static double Somme<T>(T a, T b) where T : INumber<T>
{
    var x = Convert.ToDouble(a);
    var y = Convert.ToDouble(b);
    return x + y;
}
```

Profitons de cet exemple pour revenir à la dernière partie de la déclaration de notre méthode :

```cs
//  C#
where T : INumber<T>
```

Sans cette partie là, nous rencontrerions une autre erreur au moment où nous convertissons les `T` en `double`. En effet, cette dernière partie restreint l'ensemble des types concrets que peut prendre `T` aux types (classes) qui implémentent l'interface `INumber<T>`. Sans cette restriction, le système nous renverrai une erreur car il ne pourrait pas garantir que `T` peut être converti en `double`. Remarquons par la même occasion que cette interface est elle-même générique.

Revenons à présent sur les deux appels de la méthode `Somme<T>()`. Dans ces exemples, nous avons déclaré explicitement le type de chaque variable et du générique passé à la méthode. Nous l'avons écrit ainsi pour mieux illustrer ce qu'il se passe. Toutefois, le système peut également inférer des types génériques à partir des valeurs passées à la méthode. Nous pouvons donc simplifier les appels précédents :

```cs
//  C#
var sommeEntier = Arithmetique.Somme(2, 3);
var sommeReel = Arithmetique.Somme(0.2, 0.3);
```

Cet exemple est également disponible.

- [dotnet/Program](/dotnet/techtalk/TechTalk/Program.cs)

Faisons le point de tout ce que nous avons vu jusqu'à présent. Nous avons vu deux approches qui permettent de reproduire la flexibilité d'un système de typage dynamique. La première, **le polymorphisme par héritage**, permet de créer un ensemble de types interchangeables. Bien que cette stratégie réponde à la problématique initiale, elle reproduit également la mutabilité du typage dynamique, mais une mutabilité plus controlée. C'est pourquoi nous avons vu une seconde approche, **la programmation générique** (ou polymorphisme de type) qui offre également cette flexibilité d'usage, flexibilité qui nous épargne de devoir écrire une méthode `Somme()` pour chaque type existant, et garanti également une immutabilité de type qui empêche un `Chat` de devenir un `Canard`, par exemple.

Concluons sur la programmation générique avec quelques exemples supplémentaires. Tout d'abord, nous pouvons écrire des classes génériques au même titre que nous avons écrit des méthodes génériques :

- [dotnet/Generique](/dotnet/techtalk/TechTalk/Generique.cs)

Dans cet exemple, nous définissons une classe générique `Cage<T>` dont la méthode `CapturerAutreChien<U>()` est également générique. Attardons un peu plus sur ce que fait cette méthode :

```cs
public void CapturerAutreChien<U>(U chien) where U : T
{
    if (!plein)
    {
        this.chien = chien;
        plein = true;
    }
}
```

Cette méthode prend un chien de type `U` restreint au type `T`, lui-même restreint au type `Chien`, en entrée. Lorsque nous instançons la classe `Cage<T>`, nous fixons le type de chien que la cage peut accueillir. Donc, si nous choisissons d'instancier une `Cage<T>` sur un `Golden_Retriever`, nous ne pourrons plus capturer que des `Golden_Retriever`. Si nous voulons mettre un `Rottweiler` en cage, deux options s'offrent à nous :

1) Créer une nouvelle instance de `Cage<T>` sur le type `Rottweiler`.
2) Assigner un type plus large à notre instance de `Cage<T>`, comme `Chien`.

Cet exemple nous permet d'illustrer que les deux stratégies de polymorphisme que nous avons vu sont compatibles. Regardons un dernier. Jusqu'à présent nous n'avons traité que des cas à un seul générique par soucis de simplicité. Bien entendu, nous pouvons définir autant de paramètre générique que nous en avons besoin. Nous pouvons également les mélanger à des types concrets :

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

Dans cet exemple nous avons trois paramètres génériques `T`, `U` et `V`, et deux paramètres de type concret `int` et `string`. Le premier générique `T` est retreint aux classes qui implémentent les deux interfaces `ICrier` et `Ivoler` (`Piegon` par exemple). Le deuxième générique est restreint aux instances de la classe `Cage<T>` dont le générique répond aussi aux contraintes sur `T` (`Cage<Pigeon>` par exemple). Le dernier générique n'a pas de restriction.

## Conclusion

Tout au long de ce document, nous avons vu en quoi des langages à système de typage dynamique comme **JavaScript** et des langages à système de typage statique comme **C#** diffèrent. Nous avons également vu comment exploiter les systèmes de typage statique pour conserver un maximum de flexibilité malgré les contraintes imposées. Pour ce faire, nous avons introduit les concepts de polymorphisme par héritage et de programmation générique. Nous avons également discuté des avantages et des inconvénients des deux approches au travers d'un angle d'attaque bien précis : Permettre une flexibilité comparable à celle du typage dynamique tout en garantissant une immutabilité.

Dans les faits, nous ne pouvons pas dire que les langages à typage statique dominent le marché puisque **JavaScript** et **Python**, deux langages à typage dynamique, occupent les deux premières places du classement de popularité dans le dernier rapport de [Redmonk](https://redmonk.com/sogrady/2024/09/12/language-rankings-6-24/) de juin 2024. Ils occupent également le top 10 du classement dans le dernier rapport de [TIOBE](https://www.tiobe.com/tiobe-index/) d'octobre 2024. Cependant, nous devons constater l'intérêt grandissant des développeurs pour les systèmes de typage statique. Dans ce sens, **TypeScript** occupe une place remarquable dans le classement de Redmonk. Si vous l'ignorez, **TypeScript** est un superset de **JavaScript** qui permet d'écrire du code **JavasScript** dans une versions à typage statique puis de le compiler en code **JavaScript**. Toutes les informations sont sur le site officiel.

- [TypeScript](https://www.typescriptlang.org/)

Si vous voulez expérimenter les systèmes de typage statique sans devoir apprendre un autre langage, **TypeScript** est votre meilleure option. Vous ne devriez pas rencontrer de problèmes insurmontable en migrant vers ce nouvel outil puisque **TypeScript** est déjà bien intégré dans les environnements d'exécution les plus connus comme **Deno** et **Bun**, et l'intégration **Node** arrive à grand pas. Pareil pour les frameworks les plus populaires comme **React** et **Vue**. Mention spéciale à **Angular** qui est écrit directement en **TypeScript**.
