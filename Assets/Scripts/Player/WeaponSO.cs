using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public int Damage = 1;
    public float FireRate = 0.5f;
    public GameObject HitVFXPrefab;
    public GameObject weaponPrefab;
    public bool IsAutomatic = false;
    public RuntimeAnimatorController weaponAnimator;
    public bool CanZoom = false;
    public float ZoomAmount = 10f;
    public float ZoomRotationSpeed = .3f;
    public int magazineSize = 12;
    public float shootDistance = 10f;
    public AudioClip sfxClip;
}
