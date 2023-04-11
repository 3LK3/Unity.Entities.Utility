using Unity.Entities;
using Unity.Physics;

namespace Elke.Entities.Utility.Physics
{
    public struct EntityHitCollector<T> : ICollector<T> where T : struct, IQueryResult
    {
        public bool EarlyOutOnFirstHit => true;

        public float MaxFraction { get; private set; }

        public int NumHits { get; private set; }

        public T EntityHit;

        private Entity m_Entity;

        public EntityHitCollector(Entity entity)
        {
            m_Entity = entity;

            MaxFraction = 1.0f;
            NumHits = 0;
            EntityHit = default;
        }

        public bool AddHit(T hit)
        {
            if (hit.Entity != m_Entity)
            {
                return false;
            }

            MaxFraction = hit.Fraction;
            NumHits = 1;
            EntityHit = hit;

            return true;
        }
    }
}
