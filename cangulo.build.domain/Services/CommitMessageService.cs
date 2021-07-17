using cangulo.build.abstractions;
using cangulo.build.abstractions.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace cangulo.build.domain
{
    public interface ICommitMessageService
    {
        CommitActionEnum GetAction(string msg);

        IEnumerable<CommitActionEnum> GetActions(IEnumerable<string> msgs);
    }

    public class CommitMessageService : ICommitMessageService
    {
        public CommitActionEnum GetAction(string msg)
        {
            if (Constants.CommitActionsVsMsg.Any(x => MatchActionRegex(msg, x)))
                return Constants.CommitActionsVsMsg.FirstOrDefault(x => MatchActionRegex(msg, x)).Key;

            return CommitActionEnum.Undefined;
        }

        private static bool MatchActionRegex(string msg, KeyValuePair<CommitActionEnum, string> x)
            => Regex.IsMatch(msg, x.Value, RegexOptions.IgnoreCase);

        public IEnumerable<CommitActionEnum> GetActions(IEnumerable<string> msgs)
            => msgs.Select(x => GetAction(x));
    }
}