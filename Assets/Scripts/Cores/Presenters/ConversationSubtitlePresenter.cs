using Cores.Presenters.Interfaces;
using Cores.Views.Interfaces;

namespace Cores.Presenters
{
    public class ConversationSubtitlePresenter : IConversationSubtitlePresenter
    {
        private IConversationSubtitleView _conversationSubtitleView;

        public ConversationSubtitlePresenter
        (
            IConversationSubtitleView conversationSubtitleView
        )
        {
            _conversationSubtitleView = conversationSubtitleView;
        }

        public void SetSubtitleText(string text)
        {
            _conversationSubtitleView.ConversationTextBox.text = text;
        }
    }
}
