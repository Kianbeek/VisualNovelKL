using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace CHARACTERS
{
    public class CharacterSpriteLayer
    {
        private const float DEFAULT_TRANSITION_SPEED = 3f;
        private float transitionSpeedMultiplier = 1;

        private CharacterManager characterManager => CharacterManager.instance;
        public int layer { get; private set; } = 0;
        public Image renderer { get; private set; } = null;

        public CanvasGroup rendererCG => renderer.GetComponent<CanvasGroup>();

        private List<CanvasGroup> oldRenderers = new List<CanvasGroup>();

        private Coroutine co_transitioningLayer = null;
        private Coroutine co_levelingAlpha = null;

        public bool isTransitioningLayer => co_transitioningLayer != null;
        public bool isLevelingAlpha => co_levelingAlpha != null;

        public CharacterSpriteLayer (Image defaultRenderer, int layer = 0)
        {
            renderer = defaultRenderer;
            this.layer = layer;
        }

        public void SetSprite(Sprite sprite)
        {
            renderer.sprite = sprite;
        }

        public Coroutine TransitionSprite(Sprite sprite, float speed = 1)
        {
            if (sprite == renderer.sprite)
                return null;

            if (isTransitioningLayer)
                characterManager.StopCoroutine(co_transitioningLayer);

            co_transitioningLayer = characterManager.StartCoroutine(TransitioningSprite(sprite, speed));

            return co_transitioningLayer;  
        }

        private IEnumerator TransitioningSprite(Sprite sprite, float speedMultiplier)
        {
            transitionSpeedMultiplier = speedMultiplier;

            Image newRenderer = CreateRenderer(renderer.transform.parent);
            newRenderer.sprite = sprite;

            yield return TryStartLevelingAlphas();

            co_transitioningLayer = null;
        }

        private Image CreateRenderer(Transform parent)
        {
            Image newRenderer = Object.Instantiate(renderer, parent);
            oldRenderers.Add(rendererCG);

            newRenderer.name = renderer.name;
            renderer = newRenderer;
            renderer.gameObject.SetActive(true);
            rendererCG.alpha = 0;

            return newRenderer;
        }

        private Coroutine TryStartLevelingAlphas()
        {
            if (isLevelingAlpha)
                return co_levelingAlpha;

            co_levelingAlpha = characterManager.StartCoroutine(RunAlphaLeveling());

            return co_levelingAlpha;
        }

        private IEnumerator RunAlphaLeveling()
        {
            while(rendererCG.alpha < 1 || oldRenderers.Any(oldCG => oldCG.alpha > 0))
            {
                float speed = DEFAULT_TRANSITION_SPEED * transitionSpeedMultiplier * Time.deltaTime;
                rendererCG.alpha = Mathf.MoveTowards(rendererCG.alpha, 1, DEFAULT_TRANSITION_SPEED * transitionSpeedMultiplier * Time.deltaTime);

                for (int i = oldRenderers.Count - 1; i >= 0; i--)
                {
                    CanvasGroup oldCG = oldRenderers[i];
                    oldCG.alpha = Mathf.MoveTowards(oldCG.alpha, 0, speed);

                    if (oldCG.alpha <= 0)
                    {
                        oldRenderers.RemoveAt(i);
                        Object.Destroy(oldCG.gameObject);
                    }
                }

                yield return null;
            }
            co_levelingAlpha = null;
        }
    }
}
