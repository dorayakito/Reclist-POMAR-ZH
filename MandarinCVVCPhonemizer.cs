using System;
using System.Collections.Generic;
using System.Linq;
using OpenUtau.Api;
using OpenUtau.Core.Ustx;

namespace OpenUtau.Plugin.Builtin
{

    [Phonemizer("Mandarin CVVC", "ZH CVVC", "Dorayakito", language: "ZH")]
    public class MandarinCVVCPhonemizer : Phonemizer
    {

        private static readonly HashSet<string> initials = new HashSet<string> {
            "b", "p", "m", "f",
            "d", "t", "n", "l",
            "g", "k", "h",
            "j", "q", "x",
            "zh", "ch", "sh", "r",
            "z", "c", "s",
            "y", "w"
        };

        private static readonly HashSet<string> finals = new HashSet<string> {
            "a", "o", "e", "i", "u", "v",
            "ai", "ao", "ei", "ou",
            "an", "ang", "en", "eng", "in", "ing", "ong", "un",
            "ia", "ie", "iao", "ian", "iang", "iong", "iu",
            "ua", "uo", "uai", "uan", "uang", "ui",
            "ve", "van", "vn",
            "er", "ng"
        };

        private static readonly Dictionary<string, string[]> vcFallbacks = new Dictionary<string, string[]> {
            {"t", new[] {"c"}},
            {"d", new[] {"z"}},
            {"zh", new[] {"j", "z"}},
            {"ch", new[] {"q", "c"}},
            {"sh", new[] {"x", "s"}},
            {"g", new[] {"k"}},
            {"k", new[] {"g"}},
            {"j", new[] {"zh", "z"}},
            {"q", new[] {"ch", "c"}},
            {"x", new[] {"sh", "s"}},
            {"b", new[] {"p"}},
            {"p", new[] {"b"}},
            {"r", new[] {"l"}},
            {"n", new[] {"l"}},
            {"l", new[] {"n"}},
            {"h", new[] {"f"}},
            {"f", new[] {"h"}},
        };

        private USinger? singer;

        public override void SetSinger(USinger singer)
        {
            this.singer = singer;
        }

        public override Result Process(Note[] notes, Note? prev, Note? next,
            Note? prevNeighbour, Note? nextNeighbour, Note[] prevs)
        {

            var note = notes[0];
            var lyric = note.lyric.Trim().ToLowerInvariant();
            int tone = note.tone;
            int totalDuration = notes.Sum(n => n.duration);

            if (string.IsNullOrEmpty(lyric) || lyric == "R" || lyric == "-" || lyric == "br1")
            {
                return SinglePhoneme(lyric);
            }

            if (HasAlias(lyric, tone))
            {
                var (initial, final) = ParsePinyin(lyric);

                var phonemes = new List<string>();

                if (prevNeighbour.HasValue)
                {
                    var prevLyric = prevNeighbour.Value.lyric.Trim().ToLowerInvariant();
                    var (_, prevFinal) = ParsePinyin(prevLyric);

                    if (!string.IsNullOrEmpty(prevFinal) && !string.IsNullOrEmpty(initial))
                    {
                        string vc = FindBestVC(prevFinal, initial, tone);
                        if (!string.IsNullOrEmpty(vc))
                        {
                            phonemes.Add(vc);
                        }
                    }
                }

                phonemes.Add(lyric);

                if (!nextNeighbour.HasValue && !string.IsNullOrEmpty(final))
                {
                    string ending = $"{final} -";
                    if (HasAlias(ending, tone))
                    {
                        phonemes.Add(ending);
                    }
                }

                return BuildResult(phonemes, totalDuration, tone);
            }

            return SinglePhoneme(lyric);
        }

        private (string initial, string final) ParsePinyin(string pinyin)
        {
            if (string.IsNullOrEmpty(pinyin)) return ("", "");

            if (pinyin.Length >= 2)
            {
                string twoChar = pinyin.Substring(0, 2);
                if (initials.Contains(twoChar))
                {
                    string remaining = pinyin.Substring(2);
                    return (twoChar, remaining);
                }
            }

            if (pinyin.Length >= 1)
            {
                string oneChar = pinyin.Substring(0, 1);
                if (initials.Contains(oneChar))
                {
                    string remaining = pinyin.Substring(1);
                    return (oneChar, remaining);
                }
            }

            return ("", pinyin);
        }

        private string FindBestVC(string final, string initial, int tone)
        {
            string vc = $"{final} {initial}";
            if (HasAlias(vc, tone))
            {
                return vc;
            }

            if (vcFallbacks.TryGetValue(initial, out var fallbacks))
            {
                foreach (var fallback in fallbacks)
                {
                    string vcFallback = $"{final} {fallback}";
                    if (HasAlias(vcFallback, tone))
                    {
                        return vcFallback;
                    }
                }
            }

            return "";
        }

        private Result SinglePhoneme(string phoneme)
        {
            return new Result
            {
                phonemes = new Phoneme[] {
                    new Phoneme { phoneme = phoneme, position = 0 }
                }
            };
        }

        private Result BuildResult(List<string> aliases, int totalDuration, int tone)
        {
            if (aliases.Count == 0)
            {
                return SinglePhoneme("");
            }

            if (aliases.Count == 1)
            {
                return new Result
                {
                    phonemes = new Phoneme[] {
                        new Phoneme {
                            phoneme = aliases[0],
                            position = 0
                        }
                    }
                };
            }

            var phonemes = new List<Phoneme>();

            int vcLength = Math.Min(300, totalDuration * 50 / 100);
            int endingLength = Math.Min(180, totalDuration * 25 / 100);

            for (int i = 0; i < aliases.Count; i++)
            {
                string alias = aliases[i];
                int position;

                if (i == 0)
                {
                    position = -vcLength;
                }
                else if (i == aliases.Count - 1 && alias.EndsWith("-"))
                {
                    position = totalDuration - endingLength;
                }
                else
                {
                    position = 0;
                }

                phonemes.Add(new Phoneme
                {
                    phoneme = alias,
                    position = position
                });
            }

            return new Result { phonemes = phonemes.ToArray() };
        }

        private bool HasAlias(string alias, int tone)
        {
            if (singer == null) return false;
            return singer.TryGetMappedOto(alias, tone, out _);
        }
    }
}
