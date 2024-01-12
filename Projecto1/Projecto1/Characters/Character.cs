using System;
using System.Collections.Generic;

namespace MyGameProject.Game.GameObjects
{
    public class Character
    {
        public void EquipObject(object equipedObject){
            equipedObject.Equip(this);
        }
        public void UnequipObject(object equipedObject){
            equipedObject.Unequip();
        }
        public void Attack(){
            Console.WriteLine("Ataco!");
        }
    }

}