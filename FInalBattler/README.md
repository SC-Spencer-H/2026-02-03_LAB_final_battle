PROJECT REQUIREMENTS

1) _Interface-Based Design_

	I created an "IBattlable" interface that forces implementation of all elements needed 
    to be compatible with battles using the Combat Manager, such as a variety of combat actions 
    and getters for important information like current health and name. The interface is used by 
    a Hero class and a Monster class.

2) _OOP Pillars_

    All properties in the Hero, Monster and Creations classes are private or protected. Properties
    used by the Combat Manager are obtained with getter methods.     
    The Hero and Monster classes both inherit from the Creations class, which contains shared data like 
    names and health.       
    The Hero and Monster classes both inherit from the IBattlable interface to define public behavior 
    and interactions.        
    The IBattlable interface is used as a type in the Combat Manager to achieve polymorphism between Hero 
    and Monster objects.

3) _Battle or Action System_
    
    I created a Combat Manager class that holds a list of IBattlable objects and simulates battles using 
    interface methods from the IBattlable objects, like ChooseCombatAction() and TakeDamage(). This polymorphism
    allows the system to be extended to any future classes that also implement the IBattlable interface. 

4) _Clean Design & Refactoring_

    There is no intensive logic in Main. The only duplicated code is some small bits shared by Hero and Monster
    as a result of inheriting IBattlable. There are no large switch statements or conditional trees. Objects are
    stored inside collection properties to separate them from behavior. 