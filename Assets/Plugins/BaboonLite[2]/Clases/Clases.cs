using System;
using System.Collections.Generic;
using UnityEngine;

namespace BaboOnLite
{
    //PUBLICAS
    [Serializable]
    public class Movimiento
    {
        public float duracion;
        public Vector3 destino;
        public AnimationCurve curva;

        public Movimiento(float duracion, Vector3 destino, AnimationCurve anim = null)
        {
            this.duracion = duracion;
            this.destino = destino;
            this.curva = anim ?? AnimationCurve.Linear(0f, 0f, 1f, 1f);
        }
    }
    [Serializable]
    public class Rotacion
    {
        public float duracion;
        public Quaternion destino;
        public AnimationCurve curva;

        public Rotacion(float duracion, int destino, AnimationCurve anim = null)
        {
            this.duracion = duracion;
            this.destino = Quaternion.Euler(0, 0, destino);
            this.curva = anim ?? AnimationCurve.Linear(0f, 0f, 1f, 1f);
        }
        public Rotacion(float duracion, Quaternion destino, AnimationCurve anim = null)
        {
            this.duracion = duracion;
            this.destino = destino;
            this.curva = anim ?? AnimationCurve.Linear(0f, 0f, 1f, 1f);
        }
    }
    [Serializable]
    public class DictionarySerializable<T>
    {
        public List<Elementos> data = new List<Elementos>();

        [Serializable]
        public class Elementos {
            public string indice;
            public T valor;

            public Elementos(string indice, T valor)
            {
                this.valor = valor;
                this.indice = indice;
            }
        }

        public T Get(string indice) {
            T valor = default(T);

            data.ForEach((element) =>
            {
                if (indice.ToLower() == element.indice.ToLower())
                {
                    valor = element.valor;
                }
            });

            return valor;
        }
        public T Get(int indice)  {
            return data[indice].valor;
        }

        public void Add(string indice, T valor) {
            data.Add(new Elementos(indice, valor));
        }

        public bool Inside(string indice) {
            bool dentro = false;
            data.ForEach((element) =>
            {
                if (indice.ToLower() == element.indice.ToLower()) {
                    dentro = true;
                }
            });
            return dentro;
        }
        public bool Inside(int indice) {
            return (indice >= 0 && indice < data.Count);
        }

        public List<Elementos> ToList() => data;
    }



    //PRIVADAS
    public class Trans {
        public List<Transform> trans = new List<Transform>();
        public List<RectTransform> rect = new List<RectTransform>();
    }
}
