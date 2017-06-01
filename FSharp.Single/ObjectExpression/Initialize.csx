
enum Title { Mr, Mrs, Miss }

class Person {
    public Person(Title title = Title.Mr) => this.Title = title;
    public Title Title  { get; }
    public string FirstName { set;get; }  = "";
    public string LastName { set;get; } = "";
}

var person1 = new Person();

var person2 = new Person() {
    FirstName = "Graham",
    LastName = "Wardle"
};

var person3 = new Person(Title.Miss) {
    FirstName = "Amber",
    LastName = "Marshall"
};
