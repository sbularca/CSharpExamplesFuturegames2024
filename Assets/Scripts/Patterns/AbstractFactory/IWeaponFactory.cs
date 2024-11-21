using System.Collections.Generic;

public interface IWeaponFactory {
    public List<IAttachment> attachments { get; set; }
    public IWeapon CreateWeapon();
    public IAttachment CreateWeaponAttachment();
}

public class SniperFactory : IWeaponFactory {
    public List<IAttachment> attachments { get; set; } = new ();
    public IWeapon CreateWeapon() {
        return new Sniper();
    }
    public IAttachment CreateWeaponAttachment() {
        Scope scope = new (){
            ID = "Sniper Scope"
        };
        scope.AssembleAttachment();
        attachments.Add(scope);
        return scope;
    }
}

public class SMGFactory : IWeaponFactory {
    public List<IAttachment> attachments { get; set; } = new ();
    public IWeapon CreateWeapon() {
        return new SMG();
    }
    public IAttachment CreateWeaponAttachment() {
        Silencer silencer = new () {
            ID = "SMG Silencer"
        };
        silencer.AssembleAttachment();
        attachments.Add(silencer);
        return silencer;
    }
}
