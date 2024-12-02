using HotChocolate.Types.Pagination;
using System.Linq.Dynamic.Core;

namespace graph.Extensions
{
    public class AggregateConnection<T,V>
    {
        private class Dataset
        {
            public Dictionary<string, IQueryable> Data = new Dictionary<string, IQueryable>();

            public int Count { get; private set; }

            public Dataset(Connection<T> connection, List<V> fields)
            {
                var mainDataset = connection.Edges.Select(x => x.Node).ToList();

                this.Count = mainDataset.Count();

                if (fields != null)
                {
                    foreach (var field in fields)
                    {
                        var name = field.ToString();
                        Data.Add(name, mainDataset.AsQueryable().Select(name));
                    }
                }
            }
        }

        public int Count([Parent] Connection<T> connection)
        {
            var dataset = new Dataset(connection, null);
            return dataset.Count;
        }

        public class Valore
        {
            public Valore(string field, double value)
            {
                Field = field;
                Value = value;
            }

            public string Field {  get; set; }

            public double Value { get; set; }
        }

        public List<Valore> Sum([Parent] Connection<T> connection, List<V> fields)
        {
            var dataset = new Dataset(connection, fields);

            var result = new List<Valore>();
            foreach (var field in fields)
            {
                var name = field.ToString();
                var sum = dataset.Data[name].Sum();
                result.Add(new Valore(name, Convert.ToDouble(sum)));
            }

            return result;
        }

        public List<Valore> Avg([Parent] Connection<T> connection, List<V> fields)
        {
            var dataset = new Dataset(connection, fields);

            var result = new List<Valore>();
            foreach (var field in fields)
            {
                var name = field.ToString();

                if (dataset.Count == 0)
                {
                    result.Add(new Valore(name, 0D));
                }
                else
                {
                    var data = dataset.Data[name];
                    var sum = Convert.ToDouble(data.Sum());
                    double avg = sum / dataset.Count;
                    result.Add(new Valore(name, Convert.ToDouble(avg)));
                }
            }

            return result;
        }

        public List<Valore> Max([Parent] Connection<T> connection, List<V> fields)
        {
            var dataset = new Dataset(connection, fields);

            var result = new List<Valore>();
            foreach (var field in fields)
            {
                var name = field.ToString();

                if (dataset.Count == 0)
                {
                    result.Add(new Valore(name, 0D));
                }
                else
                {
                    var max = dataset.Data[name].Max();
                    result.Add(new Valore(name, Convert.ToDouble(max)));
                }
            }

            return result;
        }

        public List<Valore> Min([Parent] Connection<T> connection, List<V> fields)
        {
            var dataset = new Dataset(connection, fields);

            var result = new List<Valore>();
            foreach (var field in fields)
            {
                var name = field.ToString();

                if (dataset.Count == 0)
                {
                    result.Add(new Valore(name, 0D));
                }
                else
                {
                    var min = dataset.Data[name].Min();
                    result.Add(new Valore(name, Convert.ToDouble(min)));
                }
            }

            return result;
        }
    }
}
