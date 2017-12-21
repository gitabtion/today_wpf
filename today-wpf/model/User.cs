using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace today_wpf.model
{
    class User
    {
        private String name;
        private String signature;
        private String avatar;
        private int sex;
        private long createdAt;
        private long updatedAt;

        public String getAvatar()
        {
            return avatar;
        }

        public void setAvatar(String avatar)
        {
            this.avatar = avatar;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getSignature()
        {
            return signature;
        }

        public void setSignature(String signature)
        {
            this.signature = signature;
        }

        public int getSex()
        {
            return sex;
        }

        public void setSex(int sex)
        {
            this.sex = sex;
        }

        public long getCreatedAt()
        {
            return createdAt;
        }

        public void setCreatedAt(long createdAt)
        {
            this.createdAt = createdAt;
        }

        public long getUpdatedAt()
        {
            return updatedAt;
        }

        public void setUpdatedAt(long updatedAt)
        {
            this.updatedAt = updatedAt;
        }
    }
}

