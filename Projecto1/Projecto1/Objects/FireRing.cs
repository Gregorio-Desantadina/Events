using System;
namespace MyGameProject.Game.GameObjects
{
    public class FireRing
    {
        private object owner = null;
        public void Equip(object newOwner){
            owner = newOwner;
        }
        public void Unequip(){
            owner = null;
        }
        public void ReturnOwner(){
            
        }
    }
}