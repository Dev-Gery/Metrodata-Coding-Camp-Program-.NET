// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//Write your JavaScript code.
const animals = [
    { name: "garfield", species: "cat", class: { name: "mamalia" } },
    { name: "gamabunta", species: "frog", class: { name: "amphibia" } },
    { name: "tom", species: "cat", class: { name: "mamalia" } },
    { name: "soren", species: "bird", class: { name: "aves" } },
    { name: "dory", species: "fish", class: { name: "pisces" } },
    { name: "nemo", species: "fish", class: { name: "pisces" } },
    { name: "marlin", species: "fish", class: { name: "pisces" } },
    { name: "zimba", species: "cat", class: { name: "mamalia" } }
]
console.log('Animals', animals);

const onlyCats = [];
for (var i = 0; i < animals.length; i++) {
    //Tugas no.1
    if (animals[i].species == "cat") {
        onlyCats.push(animals[i]);
    }
    //Tugas no.2
    else if (animals[i].species == "fish") {
        animals[i].class.name = "non-mamalia";                                      
    }                                                                               
}                                                                                   
console.log('AnimalsMod', animals);                                                 
console.log('OnlyCats', onlyCats);                                                  
console.log('OnlyCats', onlyCats);                                                  
console.log('OnlyCats', onlyCats);                                                  
console.log('onlyCats', onlycats);                                                  
                                                                                      