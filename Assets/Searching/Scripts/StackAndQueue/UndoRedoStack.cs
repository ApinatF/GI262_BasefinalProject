using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StackAndQueue
{
    public class UndoRedoStack : MonoBehaviour
    {
        public PlayerController player;
        private Vector3 playerLastPosition;

        private Stack<Vector3> undoStack = new Stack<Vector3>();
        private Stack<Vector3> redoStack = new Stack<Vector3>();

        void Start()
        {
            // 0. record the initial position
            playerLastPosition = player.transform.position;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                // 1. call Undo()
                Debug.Log("Undo");
                Undo();
            }
            else if (Input.GetKeyDown(KeyCode.Y))
            {
                // 2. call Redo()
                Debug.Log("Redo");
                Redo();
            }

            // 3. Detect if player position change, record it to undo stack
            if (Vector3.Distance(playerLastPosition, player.transform.position) > 0.1f)
            {
                undoStack.Push(playerLastPosition);
                playerLastPosition = player.transform.position;
                redoStack.Clear();
            }

        }

        public void Undo()
        {
            // 4. first, check if undo stack is empty
            if (undoStack.Count <= 0) return; 
           
            // 4. pop the last position from undo stack
            Vector3 undoPos = undoStack.Pop();
            redoStack.Push(player.transform.position);
            player.transform.position = undoPos;
            playerLastPosition = player.transform.position;

            // 5. Push the current position to the redo stack
            
            

            // 6. Move the object to the undo position

        }

        public void Redo()
        {
            // 7. first, check if redo stack is empty
            if (redoStack.Count <= 0) return;
            // 8. pop the last position from redo stack
            Vector3 redoPos = redoStack.Pop();
            undoStack.Push(player.transform.position);
            player.transform.position = redoPos;
            playerLastPosition = player.transform.position;

            // 9. Push the current position to the undo stack

            // 10. Move the object to the redo position
        }
    }
}
