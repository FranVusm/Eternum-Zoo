using UnityEngine;

public class ArmaModificable : MonoBehaviour
{
    [System.Serializable]
    public class ModificacionArma
    {
        public Vector3 posicion;
        public Quaternion rotacion;
        public Vector3 escala;
    }

    public ModificacionArma datosModificados;

    public void GuardarModificacion()
    {
        datosModificados.posicion = transform.localPosition;
        datosModificados.rotacion = transform.localRotation;
        datosModificados.escala = transform.localScale;
    }

    public void AplicarModificacion()
    {
        transform.localPosition = datosModificados.posicion;
        transform.localRotation = datosModificados.rotacion;
        transform.localScale = datosModificados.escala;
    }
}