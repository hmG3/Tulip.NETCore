// Type: tinet.indicator
// Assembly: tinet, Version=1.0.7314.43056, Culture=neutral, PublicKeyToken=null
// MVID: 2CA41E29-2115-47E0-A242-460E21C6BF25

namespace tinet
{
  public class indicator
  {
    private int index;
    private string m_name;
    private string m_full_name;
    private string[] m_inputs;
    private string[] m_options;
    private string[] m_outputs;

    public indicator(
      int index,
      string name,
      string full_name,
      string inputs,
      string options,
      string outputs)
    {
      this.index = index;
      this.m_name = name;
      this.m_full_name = full_name;
      char[] chArray1 = new char[1]{ '|' };
      this.m_inputs = inputs.Split(chArray1);
      char[] chArray2 = new char[1]{ '|' };
      this.m_options = options.Split(chArray2);
      char[] chArray3 = new char[1]{ '|' };
      this.m_outputs = outputs.Split(chArray3);
    }

    public string name()
    {
      return this.m_name;
    }

    public string full_name()
    {
      return this.m_full_name;
    }

    public int run(double[][] inputs, double[] options, double[][] outputs)
    {
      return \u003CModule\u003E.indicator_run(this.index, inputs, options, outputs);
    }

    public int start(double[] options)
    {
      return \u003CModule\u003E.indicator_start(this.index, options);
    }

    public string[] inputs()
    {
      return this.m_inputs;
    }

    public string[] options()
    {
      return this.m_options;
    }

    public string[] outputs()
    {
      return this.m_outputs;
    }
  }
}
