using UnityEngine;

[CreateAssetMenu(menuName = "SO/Dialog/DialogContext")]
public class DialogContextSO : ScriptableObject
{
	[TextArea]
    public string Dialog = "";
    public DialogContextSO NextContext = null;
}
