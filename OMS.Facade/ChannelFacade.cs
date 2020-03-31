using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMS.DAL;

namespace OMS.Facade
{
    public interface IChannelFacade
    {
        //Channel
        List<Channel> GetChannelAll();
        Channel GetChannelByID(long id);
        List<Channel> GetChannelListByParentID(long parentID);

        //ChannelType
        List<ChannelType> GetChannelTypeAll();
        ChannelType GetChannelTypeByID(int id);

        void Dispose();
    }

    class ChannelFacade: BaseFacade,IChannelFacade
    {
        public ChannelFacade(OMSDataContext database)
            : base(database)
        {
        }

        #region IChannelFacade Members

        public List<Channel> GetChannelAll()
        {
            List<Channel> channelList = new List<Channel>();
            List<Channel> channelListNew = new List<Channel>();
            channelList = Database.Channels.Where(c => c.IsRemoved == 0).ToList();
            foreach (Channel channel in channelList)
            {
                channel.ChannelType = channel.ChannelType;
                channelListNew.Add(channel);
            }
            return channelListNew;
        }

        public Channel GetChannelByID(long id)
        {
            Channel channel = new Channel();
            channel = Database.Channels.Single(c => c.IID == id && c.IsRemoved == 0);
            channel.ChannelType = channel.ChannelType;
            return channel;
        }

        private List<Channel> channelListChild = new List<Channel>();

        public List<Channel> GetChannelListByParentID(long parentID)
        {
            List<Channel> channelList = new List<Channel>();
            
            channelList = Database.Channels.Where(c => c.ParentID == parentID && c.IsRemoved == 0).ToList();
            foreach (Channel channel in channelList)
            {
                GetChannelListByParentID(channel.IID);
                channel.ChannelType = channel.ChannelType;
                channelListChild.Add(channel);
            }
            return channelListChild;
        }

        #endregion

        

        public List<ChannelType> GetChannelTypeAll()
        {
            List<ChannelType> channelTypeList = new List<ChannelType>();
            channelTypeList = Database.ChannelTypes.Where(ct => ct.IsRemoved == 0).ToList();
            return channelTypeList;
        }

        public ChannelType GetChannelTypeByID(int id)
        {
            ChannelType channelType = new ChannelType();
            channelType = Database.ChannelTypes.Single(ct => ct.IID == id && ct.IsRemoved == 0);
            return channelType;
        }

        
    }
}
