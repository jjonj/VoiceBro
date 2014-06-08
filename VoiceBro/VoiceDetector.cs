using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Windows.Forms;

namespace VoiceBro
{
    public class VoiceDetector
    {

        private GrammarBuilder grammarBuilder;
        private Grammar grammar;
        private ActionManager actionManager;
        private SpeechRecognitionEngine recognizer;

        public VoiceDetector(ActionManager actionManager, Choices choices = null)
        {
            if (choices != null)
            {
                grammarBuilder = choices.ToGrammarBuilder();
            }
            else
            {
                grammarBuilder = new GrammarBuilder();
            }
            grammar = new Grammar(grammarBuilder);
            this.actionManager = actionManager;
            recognizer = new SpeechRecognitionEngine();
            recognizer.LoadGrammar(grammar);
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(this.recognized);
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        public void SetCommands(Choices choices)
        {
            grammarBuilder = choices.ToGrammarBuilder();
            grammar = new Grammar(grammarBuilder);
        }


        public void Start()
        {
        }

        public void Stop()
        {
        }

        private void recognized(object sender, SpeechRecognizedEventArgs args)
        {

            if (args.Result.Confidence > 0.9)
            {
                Console.WriteLine(args.Result.Confidence);
                Console.WriteLine(args.Result.Text);
                MessageBox.Show("YAY");
            }
        }

    }
}
