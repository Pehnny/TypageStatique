mod examples;

use examples::somme;

fn main() {
    let result = somme::somme(2, 3);
    println!("{}", result);
}
