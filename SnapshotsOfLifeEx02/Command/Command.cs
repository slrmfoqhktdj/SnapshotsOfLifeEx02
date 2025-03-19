using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapshotsOfLifeEx02
{
    abstract class Command
    {
        protected CameraModel _model;

        public Command(ref CameraModel model)
        {
            _model = model;
        }

        public CameraModel GetCameraModel()
        {
            return _model;
        }

        public virtual bool Execute()
        {
            return true;
        }
    }
}
